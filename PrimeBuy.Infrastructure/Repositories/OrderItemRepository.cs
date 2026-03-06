using PrimeBuy.Application.Interfaces.Repositories;
using PrimeBuy.Domain.Models;
using PrimeBuy.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeBuy.Infrastructure.Repositories
{
    public class OrderItemRepository : GenericRepository<OrderItem>,IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext db_context) : base(db_context)
        {
        }
    }
}
