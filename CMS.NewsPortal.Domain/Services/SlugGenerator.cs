using CMS.NewsPortal.Domain.Services;
using CMS.NewsPortal.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CMS.NewsPortal.Application.Common.Interfaces;

namespace CMS.NewsPortal.Infrastructure.Services
{
    public class SlugGenerator : ISlugGenerator
    {
        private readonly IArticleRepository _repository;

        public SlugGenerator(IArticleRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> GenerateSlugAsync(string title)
        {
            string baseSlug = Regex.Replace(
                title.ToLower(), @"[^a-z0-9\s-]", "")
                .Trim()
                .Replace(" ", "-");

            string slug = baseSlug;
            int counter = 1;

            while (await _repository.ExistsBySlugAsync(slug))
            {
                slug = $"{baseSlug}-{counter}";
                counter++;
            }

            return slug;
        }
    }
}