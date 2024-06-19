

using API.Models;

namespace API.Repositoty.IRepositoty
{
    public interface IUnitOfWork
    {
        IRepository<DiscountCode> DiscountCodeRepository { get; }
        IRepository<Notice> NoticeRepository { get; }
        IRepository<Order> OrderRepository { get; }
        IRepository<OrderItem> OrderItemRepository { get; }
        IRepository<Payment> PaymentRepository { get; }
        IRepository<Product> ProductRepository { get; }
        IRepository<Role> RoleRepository { get; }
        IRepository<User> UserRepository { get; }

        void Save();
    }
}
