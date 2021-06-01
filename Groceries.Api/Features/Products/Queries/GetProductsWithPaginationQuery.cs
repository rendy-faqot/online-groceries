using Domain.Entities;
using Groceries.Api.Common.Mappings;
using Groceries.Api.Common.Models;
using Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Groceries.Api.Features.Products.Queries
{
    public class GetProductsWithPaginationQuery : IRequest<PaginatedList<Product>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetProductsWithPaginationQueryHandler : IRequestHandler<GetProductsWithPaginationQuery, PaginatedList<Product>>
    {
        private readonly ApplicationDbContext _context;

        public GetProductsWithPaginationQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Product>> Handle(GetProductsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Products
                .OrderBy(x => x.Name)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            result.Items.ForEach(x => x.ImageUrl = $"https://localhost:5001/Images/{x.ImageUrl}");
            return result;
        }
    }
}
