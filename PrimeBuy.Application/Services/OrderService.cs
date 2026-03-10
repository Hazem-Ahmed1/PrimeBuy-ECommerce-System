using PrimeBuy.Application.Interfaces.Services;
using PrimeBuy.Application.Interfaces.UnitOfWork;
using PrimeBuy.Domain.Enums;
using PrimeBuy.Domain.Models;

namespace PrimeBuy.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartService _cartService;

        public OrderService(IUnitOfWork unitOfWork, ICartService cartService)
        {
            _unitOfWork = unitOfWork;
            _cartService = cartService;
        }

        public async Task<Order> PlaceOrderAsync(string userId, string country, string city, string street, string zipCode)
        {
            var cart = await _cartService.GetOrCreateCartAsync(userId);

            if (!cart.CartItems.Any())
                throw new InvalidOperationException("Cart is empty.");

            var address = new Address(userId, country, city, street, zipCode, false);
            await _unitOfWork.Addresses.AddAsync(address);
            await _unitOfWork.SaveChangesAsync();

            var orderNumber = GenerateOrderNumber();
            var order = new Order(userId, address.Id, orderNumber);
            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();

            decimal total = 0;
            foreach (var cartItem in cart.CartItems)
            {
                var orderItem = new OrderItem(order.OrderId, cartItem.ProductId, cartItem.Product.Price, cartItem.Quantity);
                total += cartItem.Product.Price * cartItem.Quantity;
                await _unitOfWork.OrderItems.AddAsync(orderItem);
            }

            order.TotalAmount = total;
            _unitOfWork.Orders.Update(order);
            _unitOfWork.CartItems.DeleteRange(cart.CartItems);
            await _unitOfWork.SaveChangesAsync();

            return order;
        }

        public async Task<IEnumerable<Order>> GetUserOrdersAsync(string userId)
        {
            return await _unitOfWork.Orders.GetUserOrdersAsync(userId);
        }

        public async Task<Order?> GetOrderByIdAsync(int orderId)
        {
            return await _unitOfWork.Orders.GetOrderByIdWithDetailsAsync(orderId);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _unitOfWork.Orders.GetAllOrdersWithDetailsAsync();
        }

        public async Task UpdateOrderStatusAsync(int orderId, int status)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
            if (order != null)
            {
                order.Status = (OrderStatus)status;
                await _unitOfWork.SaveChangesAsync();
            }
        }

        private static string GenerateOrderNumber()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            return new string(Enumerable.Range(0, 8).Select(_ => chars[random.Next(chars.Length)]).ToArray());
        }
    }
}
