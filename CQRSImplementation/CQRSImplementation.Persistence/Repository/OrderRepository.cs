using CQRSImplementation.Application.Interfaces.IRepository;
using CQRSImplementation.Domain.Model;
using CQRSImplementation.Persistence.Context;

namespace CQRSImplementation.Persistence.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext context;

        public OrderRepository(ApplicationDbContext _context) : base(_context)
        {
            this.context = _context;
        }
    }
}
