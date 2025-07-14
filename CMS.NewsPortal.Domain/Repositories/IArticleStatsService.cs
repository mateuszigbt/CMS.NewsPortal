using CMS.NewsPortal.Domain.Entities;
using CMS.NewsPortal.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Domain.Repositories
{
    public interface IArticleStatsService
    {
        ArticleStats GetStats(IEnumerable<Article> articles, IEnumerable<Category> categories);
    }
}