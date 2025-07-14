using CMS.NewsPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Domain.Repositories
{
    public interface IArticleRepository
    {
        Task<Article?> GetByIdAsync(Guid id);
        Task<List<Article>> GetAllAsync(string? status = null);
        Task AddAsync(Article article);
        Task UpdateAsync(Article article);
        Task<bool> ExistsBySlugAsync(string slug);
    }
}