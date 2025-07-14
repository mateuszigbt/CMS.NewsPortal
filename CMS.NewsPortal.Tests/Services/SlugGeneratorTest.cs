using CMS.NewsPortal.Domain.Entities;
using CMS.NewsPortal.Domain.Repositories;
using CMS.NewsPortal.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace CMS.NewsPortal.Tests.Services
{
    public class SlugGeneratorTest
    {
        private class FakeRepo : IArticleRepository
        {
            private readonly List<Article> _list;

            public FakeRepo(List<Article> seed)
            {
                _list = seed.ToList();
            }

            public Task<bool> ExistsBySlugAsync(string slug) 
            {
                return Task.FromResult(_list.Any(a=> a.Slug == slug));
            }

            public Task AddAsync(Article article)
            {
                _list.Add(article);
                return Task.CompletedTask;
            }

            public Task<List<Article>> GetAllAsync(string? status = null) 
            {
                return Task.FromResult<List<Article>>(_list);
            }

            public Task<Article?> GetByIdAsync(Guid id)
            {
                return Task.FromResult<Article?>(null);
            }

            public Task UpdateAsync(Article article)
            {
                return Task.CompletedTask;
            }
        }

        [Fact]
        private async Task GenerateSlugHandlesDuplicates()
        {
            var repo = new FakeRepo(new[] 
            { 
                new Article { Slug = "hello-world" } 
            }.ToList());

            var generator = new SlugGenerator(repo);

            var slug1 = await generator.GenerateSlugAsync("Hello world");
            await repo.AddAsync(new Article { Slug = slug1 });
            var slug2 = await generator.GenerateSlugAsync("Hello world");

            slug1.Should().Be("hello-world-1");
            slug2.Should().Be("hello-world-2");
        }
    }
}