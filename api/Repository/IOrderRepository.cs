using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto;

namespace api.Repository
{
    public interface IOrderRepository
    {
        void PlaceOrder(InsertOrderObject order);
    }
}
