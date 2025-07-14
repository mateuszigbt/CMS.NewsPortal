using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Application.Common.Models.Articles
{
    public record GetArticlesDto(
        Guid Id,
        string Title,
        string Content,
        string Author,
        string Slug,
        string Status,
        DateTime CreatedAt,
        string? CategoryName);
}