using CMS.NewsPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Domain.Entities
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string Slug { get; set; } = default!;
        public ArticleStatus Status { get; set; } = ArticleStatus.Draft;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CategoryId { get; set; }
    }
}