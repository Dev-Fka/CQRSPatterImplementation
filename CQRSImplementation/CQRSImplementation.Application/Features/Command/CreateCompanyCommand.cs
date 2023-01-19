using AutoMapper;
using CQRSImplementation.Application.Interfaces.IRepository;
using CQRSImplementation.Domain.Model;
using MediatR;

namespace CQRSImplementation.Application.Features.Command
{
    public class CreateCompanyCommand : IRequest<bool>
    {
        public string CompanyName { get; set; }
        public bool IsApprovedCompany { get; set; }
        public DateTime BeginOrderTime { get; set; }
        public DateTime EndOrderTime { get; set; }



        public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, bool>
        {
            private readonly ICompanyRepository repo;
            private readonly IMapper mapper;
            public CreateCompanyHandler(ICompanyRepository repo, IMapper mapper)
            {
                this.repo = repo;
                this.mapper = mapper;
            }

            public async Task<bool> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
            {
                var company = mapper.Map<Company>(request);

                return await repo.AddAsync(company);

            }
        }

    }
}
