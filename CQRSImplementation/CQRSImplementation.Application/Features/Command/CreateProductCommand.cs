using AutoMapper;
using CQRSImplementation.Application.Interfaces.IRepository;
using CQRSImplementation.Domain.Model;
using MediatR;

namespace CQRSImplementation.Application.Features.Command
{
    public class CreateProductCommand : IRequest<bool>
    {
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public Double Price { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
        {
            private readonly IProductRepository repo;
            private readonly IMapper mapper;

            public CreateProductCommandHandler(IProductRepository repo, IMapper mapper)
            {
                this.repo = repo;
                this.mapper = mapper;
            }

            public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = mapper.Map<Product>(request);

                return await repo.AddAsync(product);
            }
        }

    }
}
