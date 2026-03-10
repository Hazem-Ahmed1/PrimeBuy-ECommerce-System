using PrimeBuy.Application.Interfaces.Repositories;
using PrimeBuy.Application.Interfaces.UnitOfWork;
using PrimeBuy.Infrastructure.Data;
using PrimeBuy.Infrastructure.Repositories;

namespace PrimeBuy.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IProductRepository? _products;
        private ICategoryRepository? _categories;
        private IOrderItemRepository? _orderItems;
        private ICartRepository? _carts;
        private ICartItemRepository? _cartItems;
        private IOrderRepository? _orders;
        private IAddressRepository? _addresses;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProductRepository Products => _products ??= new ProductRepository(_context);
        public ICategoryRepository Categories => _categories ??= new CategoryRepository(_context);
        public IOrderItemRepository OrderItems => _orderItems ??= new OrderItemRepository(_context);
        public ICartRepository Carts => _carts ??= new CartRepository(_context);
        public ICartItemRepository CartItems => _cartItems ??= new CartItemRepository(_context);
        public IOrderRepository Orders => _orders ??= new OrderRepository(_context);
        public IAddressRepository Addresses => _addresses ??= new AddressRepository(_context);

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
