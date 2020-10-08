using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api.Configuration;
using api.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace api.Services
{
    public class SendGridService : INotificationService
    {
        private readonly string _apiKey;
        private readonly string _from;
        public SendGridService(ISendGridSettings settings)
        {
            _apiKey = settings.ApiKey;
            _from = settings.From;
        }

        private string ListOrderedDishes(IEnumerable<OrderedDish> orderedDishes)
        {
            var content = new StringBuilder();
            foreach (var orderedDish in orderedDishes)
            {
                content.Append($"{orderedDish.Quantity}x {orderedDish.Name}.");
                if (orderedDish.Extras != null && orderedDish.Extras.Any())
                {
                    content.AppendLine($" Dodatki: {string.Join(", ", orderedDish.Extras.Select(x => x.Name).ToArray())}.");
                }
                else
                {
                    // if there are no extras append new line for the next ordered dish 
                    content.AppendLine();
                }

            }

            return content.ToString();
        }
        public async Task SendNotification(string receiver, Order order)
        {
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress(_from);
            const string subject = "PizzaPack przyjęło Twoje zamówienie!";
            var to = new EmailAddress(receiver);
            var emailContent = new StringBuilder();
            emailContent.AppendLine("Twoje zamówienie zostało przyjęte.");
            emailContent.AppendLine($"Całkowita kwota Twojego zamówienia: {order.TotalPrice} zł.");
            emailContent.AppendLine("Zamówione produkty:");
            emailContent.AppendLine(ListOrderedDishes(order.Dishes));
            emailContent.AppendLine($"Identyfikator zamówienia: {order.OrderIdentifier}");

            var msg = MailHelper.CreateSingleEmail(from, to, subject, emailContent.ToString(), string.Empty);
            await client.SendEmailAsync(msg);
        }

    }
}
