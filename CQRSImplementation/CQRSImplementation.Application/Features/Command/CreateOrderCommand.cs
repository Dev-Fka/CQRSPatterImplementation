using AutoMapper;
using CQRSImplementation.Application.Exceptions;
using CQRSImplementation.Application.Interfaces.IRepository;
using CQRSImplementation.Domain.Model;
using MediatR;

namespace CQRSImplementation.Application.Features.Command
{
    public class CreateOrderCommand : IRequest<bool>
    {

        public int ProductId { get; set; }
        public int CompanyId { get; set; }
        public string OrderedName { get; set; } = null!;
        public DateTime OrderedDate { get; set; } = DateTime.Now;


        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
        {
            private readonly IOrderRepository repo;
            private readonly ICompanyRepository companyRepo;
            private readonly IProductRepository productRepo;
            private readonly IMapper mapper;

            public CreateOrderCommandHandler(IOrderRepository repo, ICompanyRepository companyRepo, IProductRepository productRepo, IMapper mapper)
            {
                this.repo = repo;
                this.companyRepo = companyRepo;
                this.productRepo = productRepo;
                this.mapper = mapper;
            }

            public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                var company = await companyRepo.GetByIdAsync(request.CompanyId);

                var product = await productRepo.GetByIdAsync(request.ProductId);

                if (company == null || product == null)
                {
                    throw new Exception("Ürün yada Firma bilgisi bulunamadı.");
                }

                if (!company.IsApprovedCompany)
                {
                    throw new IsNotApprovedException();

                }
                if (!(company.EndOrderTime > request.OrderedDate && company.BeginOrderTime < request.OrderedDate))
                {
                    throw new TimesNotAvaibleException(company.CompanyName);
                }
                var order = mapper.Map<Order>(request);

                order.Product = product;
                order.Company = company;

                return await repo.AddAsync(order);
            }
        }
    }
}
