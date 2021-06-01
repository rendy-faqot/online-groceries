using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Groceries.Api.Features.Products.Queries
{
    public class GetProductDetailQuery : IRequest<Product>
    {
        public string Id { get; set; }
    }

    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, Product>
    {
        private readonly ApplicationDbContext _context;

        public GetProductDetailQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.FindAsync(Guid.Parse(request.Id));
        }
    }
}
