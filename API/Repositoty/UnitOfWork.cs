
using API.DBContext;
using API.Models;
using API.Repositoty.IRepositoty;

namespace API.Repositoty
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ThoiTrangContext context;
        private IRepository<DiscountCode> discountCodeRepository;
        private IRepository<Notice> noticeRepository;
        private IRepository<Order> orderRepository ;
        private IRepository<OrderItem> orderItemRepository ;
        private IRepository<Payment> paymentRepository ;
        private IRepository<Product> productRepository ;
        private IRepository<Role> roleRepository ;
        private IRepository<User> userRepository ; 

        public UnitOfWork(ThoiTrangContext context)
        {
            this.context = context;
        }
        public IRepository<DiscountCode> DiscountCodeRepository
        {
            get
            {
                return discountCodeRepository ??= new Repository<DiscountCode>(context);
            }
        }

        public IRepository<Notice> NoticeRepository
        {
            get
            {
                return noticeRepository ??= new Repository<Notice>(context);
            }
        }

        public IRepository<Order> OrderRepository
        {
            get
            {
                return orderRepository ??= new Repository<Order>(context);
            }
        }

        public IRepository<OrderItem> OrderItemRepository
        {
            get
            {
                return orderItemRepository ??= new Repository<OrderItem>(context);
            }
        }

        public IRepository<Payment> PaymentRepository
        {
            get
            {
                return paymentRepository ??= new Repository<Payment>(context);
            }
        }

        public IRepository<Product> ProductRepository
        {
            get
            {
                return productRepository ??= new Repository<Product>(context);
            }
        }

        public IRepository<Role> RoleRepository
        {
            get
            {
                return roleRepository ??= new Repository<Role>(context);
            }
        }

        public IRepository<User> UserRepository
        {
            get
            {
                return userRepository ??= new Repository<User>(context);
            }
        }

        


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposed = true;
            }
        }
    }
}
