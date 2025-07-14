using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Application.Articles.Commands.PublishArticle
{
    public record PublishArticleCommand(Guid Id) : IRequest<Unit>;
}