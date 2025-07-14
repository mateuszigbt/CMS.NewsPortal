using CMS.NewsPortal.Domain.Entities;
using CMS.NewsPortal.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Infrastructure.Data
{
    public class EfCategoryRepository : ICategoryRepository
    {
        private static readonly List<Category> _categories = new List<Category>();

        public Task<List<Category>> GetAllAsync()
        {
            return Task.FromResult<List<Category>>(_categories);
        }

        public Task AddAsync(Category category) 
        {
            _categories.Add(category);
            return Task.CompletedTask;
        }

        public Task<bool> ExistsByNameAsync(string name) 
        {
            return Task.FromResult(_categories.Any(c => c.Name.Equals(name, StringComparison.Ordinal)));
        }
    }
}