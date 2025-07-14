using CMS.NewsPortal.Domain.Entities;
using CMS.NewsPortal.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<Category>>
    {
        private readonly ICategoryRepository _repo;

        public GetCategoriesQueryHandler(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Category>> Handle(GetCategoriesQuery query, CancellationToken cancellationToken) 
        {
            return _repo.GetAllAsync();
        }
    }
}