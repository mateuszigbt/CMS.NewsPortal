using CMS.NewsPortal.Domain.Entities;
using CMS.NewsPortal.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Application.ArticlesStats.Queries
{
    public class GetArticleStatsQueryHandler : IRequestHandler<GetArticleStatsQuery, ArticleStats>
    {
        private readonly IArticleRepository _artRepo;
        private readonly ICategoryRepository _catRepo;
        private readonly IArticleStatsService _artStatRepo;

        public GetArticleStatsQueryHandler(IArticleRepository artRepo, ICategoryRepository catRepo, IArticleStatsService artStatRepo) 
        { 
            _artRepo = artRepo;
            _catRepo = catRepo;
            _artStatRepo = artStatRepo;
        }

        public async Task<ArticleStats> Handle(GetArticleStatsQuery query, CancellationToken cancellationToken)
        {
            var article = await _artRepo.GetAllAsync(null);
            var categories = await _catRepo.GetAllAsync();

            return _artStatRepo.GetStats(article, categories);
        }
    }
}