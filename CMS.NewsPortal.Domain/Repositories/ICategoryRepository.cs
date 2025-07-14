using CMS.NewsPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task AddAsync(Category category);
        Task<bool> ExistsByNameAsync(string name);
    }
}