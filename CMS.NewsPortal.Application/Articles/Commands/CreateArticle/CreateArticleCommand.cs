using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CMS.NewsPortal.Application.Articles.Commands.CreateArticle
{
    public class CreateArticleCommand : IRequest<Guid>
    {
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public string Author { get; set; } = default!;
    }
}