using CQRSImplementation.Application.Interfaces.IRepository;
using CQRSImplementation.Domain.Model;
using CQRSImplementation.Persistence.Context;

namespace CQRSImplementation.Persistence.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext context;
        public ProductRepository(ApplicationDbContext _context) : base(_context)
        {
            this.context = _context;
        }

    }
}
