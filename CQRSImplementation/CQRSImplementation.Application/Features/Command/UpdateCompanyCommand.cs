using AutoMapper;
using CQRSImplementation.Application.Interfaces.IRepository;
using CQRSImplementation.Domain.Model;
using MediatR;

namespace CQRSImplementation.Application.Features.Command
{
    public class UpdateCompanyCommand : IRequest<bool>
    {
        public string CompanyName { get; set; }
        public bool IsApprovedCompany { get; set; }
        public DateTime BeginOrderTime { get; set; }
        public DateTime EndOrderTime { get; set; }
        public int Id { get; set; }

        public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, bool>
        {
            private readonly ICompanyRepository Repo;
            private readonly IMapper mapper;

            public UpdateCompanyHandler(ICompanyRepository repo, IMapper mapper)
            {
                Repo = repo;
                this.mapper = mapper;
            }

            public async Task<bool> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
            {

                var updatedCompany = mapper.Map<Company>(request);

                return await Repo.UpdateAsync(updatedCompany);

            }
        }
    }
}

