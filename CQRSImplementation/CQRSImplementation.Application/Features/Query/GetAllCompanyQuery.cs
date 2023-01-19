using CQRSImplementation.Application.Interfaces.IRepository;
using CQRSImplementation.Domain.Model;
using MediatR;

namespace CQRSImplementation.Application.Features.Query
{
    public class GetAllCompanyQuery : IRequest<IEnumerable<Company>>
    {

        public class GetAllCompanyHandler : IRequestHandler<GetAllCompanyQuery, IEnumerable<Company>>
        {

            private readonly ICompanyRepository repo;
            public GetAllCompanyHandler(ICompanyRepository _repo)
            {
                this.repo = _repo;
            }

            public async Task<IEnumerable<Company>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
            {
                return await repo.GetAllAsync();

            }
        }

    }
}
