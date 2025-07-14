using CMS.NewsPortal.Application.Common.Models.Articles;
using CMS.NewsPortal.Domain.Entities;
using CMS.NewsPortal.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Application.Articles.Queries.GetArticles
{
    public class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, List<GetArticlesDto>>
    {
        private readonly IArticleRepository _artRepo;
        private readonly ICategoryRepository _catRepo;

        public GetArticlesQueryHandler(IArticleRepository artRepo, ICategoryRepository catRepo)
        {
            _artRepo = artRepo;
            _catRepo = catRepo;
        }

        public async Task<List<GetArticlesDto>> Handle(GetArticlesQuery query, CancellationToken cancellationToken)
        {
            var articles = await _artRepo.GetAllAsync(query.Status);
            var categories = (await _catRepo.GetAllAsync()).ToDictionary(c => c.Id, c => c.Name);

            return articles.Select(a => a.ToDto(categories)).ToList();
        }
    }
}