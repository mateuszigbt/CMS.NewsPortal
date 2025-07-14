using CMS.NewsPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Application.Common.Models.Articles
{
    public static class GetArticlesDtoExtensions
    {
        public static GetArticlesDto ToDto(this Article article, IDictionary<Guid, string> categoryDict)
        {
            string? categoryName = null;

            if (article.CategoryId.HasValue && categoryDict.TryGetValue(article.CategoryId.Value, out var name))
            {
                categoryName = name;
            }

            return new GetArticlesDto(
                article.Id,
                article.Title,
                article.Content,
                article.Author,
                article.Slug,
                article.Status.ToString(),
                article.CreatedAt,
                categoryName
                );
        }
    }
}