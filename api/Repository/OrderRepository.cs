using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using api.Dto;
using Microsoft.Extensions.Logging;
using Npgsql;
using Npgsql.PostgresTypes;
using NpgsqlTypes;

namespace api.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<OrderRepository> _logger;
        public OrderRepository(string connectionString, ILogger<OrderRepository> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        private long CreateOrder(NpgsqlConnection connection, InsertOrderObject order)
        {
            object createdOrderId;
            using (var cmd = new NpgsqlCommand("create_order", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_email", NpgsqlDbType.Varchar, order.Email);
                cmd.Parameters.AddWithValue("_notes", NpgsqlDbType.Text, order.Notes);
                cmd.Parameters.AddWithValue("_order_time", NpgsqlDbType.TimestampTz, order.OrderTime);
                createdOrderId = cmd.ExecuteScalar();
            }

            return (long)createdOrderId;
        }

        private long AddDishToOrder(NpgsqlConnection connection, long orderId, OrderDishObject dish)
        {
            object orderedDishId;
            using (var cmd = new NpgsqlCommand("add_dish_to_order", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_order_id", NpgsqlDbType.Bigint, orderId);
                cmd.Parameters.AddWithValue("_dish_id", NpgsqlDbType.Integer, dish.DishIdentifier);
                cmd.Parameters.AddWithValue("_quantity", NpgsqlDbType.Integer, dish.Quantity);
                orderedDishId = cmd.ExecuteScalar();
            }

            return (long)orderedDishId;
        }

        private void AddAdditiveToOrder(NpgsqlConnection connection, long orderedDishId, OrderAdditiveObject additive)
        {
            using (var cmd = new NpgsqlCommand("add_additive_to_ordered_dish", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_ordered_dish_id", NpgsqlDbType.Bigint, orderedDishId);
                cmd.Parameters.AddWithValue("_additive_id", NpgsqlDbType.Integer, additive.AdditiveIdentifier);
                cmd.Parameters.AddWithValue("_quantity", NpgsqlDbType.Integer, additive.Quantity);
                cmd.ExecuteNonQuery();
            }
        }

        private decimal CalculateOrderValue(NpgsqlConnection connection, long orderId)
        {
            object orderValue;
            using (var cmd = new NpgsqlCommand("calculate_order_value", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_order_id", NpgsqlDbType.Bigint, orderId);
                orderValue = cmd.ExecuteScalar();
            }

            return (decimal)orderValue;
        }

        private void InsertOrderValue(NpgsqlConnection connection, long orderId, decimal orderValue)
        {
            using (var cmd = new NpgsqlCommand("UPDATE orders SET total_price = @calculated_price WHERE order_id = @created_order_id", connection))
            {
                cmd.Parameters.AddWithValue("calculated_price", orderValue);
                cmd.Parameters.AddWithValue("created_order_id", orderId);
                cmd.ExecuteNonQuery();
            }
        }


        public void PlaceOrder(InsertOrderObject order)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction(IsolationLevel.Serializable);
                try
                {
                    long orderId = CreateOrder(connection, order);

                    foreach (var dish in order.Dishes)
                    {
                        long orderedDishId = AddDishToOrder(connection, orderId, dish);
                        if (dish.Additives.Any())
                        {
                            foreach (var additive in dish.Additives)
                            {
                                AddAdditiveToOrder(connection, orderedDishId, additive);
                            }
                        }
                    }

                    decimal orderValue = CalculateOrderValue(connection, orderId);
                    InsertOrderValue(connection, orderId, orderValue);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogError(ex, "Error occurred during placing an order");
                }


            }
        }
    }
}
