using CMS.NewsPortal.Domain.Entities;
using CMS.NewsPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.NewsPortal.Domain.Repositories;

namespace CMS.NewsPortal.Domain.Services
{
    public class ArticleStatsService : IArticleStatsService
    {
        public ArticleStats GetStats(IEnumerable<Article> articles, IEnumerable<Category> categories)
        {
            int published = articles.Count(a => a.Status == ArticleStatus.Published);
            int draft = articles.Count(a => a.Status == ArticleStatus.Draft);

            var mostUsedCatId = articles
                .Where(a => a.CategoryId.HasValue)
                .GroupBy(a => a.CategoryId!.Value)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

            string? catName = mostUsedCatId == Guid.Empty ? null : categories.FirstOrDefault(c => c.Id == mostUsedCatId)?.Name;

            return new ArticleStats(published, draft, catName);
        }
    }
}