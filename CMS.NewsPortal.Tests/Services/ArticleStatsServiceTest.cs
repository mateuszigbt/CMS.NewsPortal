using CMS.NewsPortal.Domain.Entities;
using CMS.NewsPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using CMS.NewsPortal.Domain.Services;

namespace CMS.NewsPortal.Tests.Services
{
    public class ArticleStatsServiceTest
    {
        [Fact]
        public void GetStatsShouldReturnCorrectValues()
        {
            var techId = Guid.NewGuid();
            var sportId = Guid.NewGuid();

            var articles = new List<Article>
            {
                new Article { Status = ArticleStatus.Published, CategoryId = techId },
                new Article { Status = ArticleStatus.Published, CategoryId = techId },
                new Article { Status = ArticleStatus.Draft, CategoryId = sportId },
                new Article { Status = ArticleStatus.Draft, CategoryId = sportId },
                new Article { Status = ArticleStatus.Draft, CategoryId = sportId }
            };

            var categories = new List<Category>
            {
                new Category { Id = techId, Name = "Tech" },
                new Category { Id = sportId, Name = "Sport" },
            };

            var svc = new ArticleStatsService();
            var stats = svc.GetStats(articles, categories);

            stats.PublishedCount.Should().Be(2);
            stats.DraftCount.Should().Be(3);
            stats.MostUsedCategory.Should().Be("Sport");
        }
    }
}