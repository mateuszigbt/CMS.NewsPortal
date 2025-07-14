using CMS.NewsPortal.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Application.ArticlesStats.Queries
{
    public record GetArticleStatsQuery : IRequest<ArticleStats>;
}