using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Application.Common.Models.Articles
{
    public record UpdateArticleDto(
        string Title,
        string Content, 
        string Author);
}