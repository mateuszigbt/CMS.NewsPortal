using CMS.NewsPortal.Domain.Entities;
using CMS.NewsPortal.Domain.Enums;
using CMS.NewsPortal.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Infrastructure.Data
{
    public class EfArticleRepository : IArticleRepository
    {
        private static readonly List<Article> _articles = new();

        public Task AddAsync(Article article)
        {
            _articles.Add(article);
            return Task.CompletedTask;
        }

        public Task<List<Article>> GetAllAsync(string? status = null) 
        {
            List<Article> result = _articles;

            if (!string.IsNullOrWhiteSpace(status) && Enum.TryParse<ArticleStatus>(status, true, out var parsedStatus))
            {
                result = _articles.Where(a => a.Status == parsedStatus).ToList();
            }

            return Task.FromResult(result);
        }

        public Task<Article?> GetByIdAsync(Guid id) 
        {
            var article = _articles.FirstOrDefault(a => a.Id == id);
            return Task.FromResult(article);
        }

        public Task UpdateAsync(Article article) 
        {
            var index = _articles.FindIndex(a => a.Id == article.Id);
            
            if (index != -1)
            {
                _articles[index] = article;
            }

            return Task.CompletedTask;
        }

        public Task<bool> ExistsBySlugAsync(string slug)
        {
            bool exists = _articles.Any(a => a.Slug.Equals(slug, StringComparison.Ordinal));
            return Task.FromResult(exists);
        }
    }
}