using CQRSImplementation.Application.Interfaces.IRepository;
using CQRSImplementation.Domain.Model;
using CQRSImplementation.Persistence.Context;

namespace CQRSImplementation.Persistence.Repository
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext context;
        public CompanyRepository(ApplicationDbContext _context) : base(_context)
        {
            this.context = _context;
        }

    }
}
