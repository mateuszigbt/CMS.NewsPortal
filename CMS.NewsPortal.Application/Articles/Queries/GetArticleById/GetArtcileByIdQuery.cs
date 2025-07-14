using CMS.NewsPortal.Application.Common.Models.Articles;
using CMS.NewsPortal.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Application.Articles.Queries.GetArticleById
{
    public record GetArtcileByIdQuery(Guid Id) : IRequest<GetArticlesDto?>;
}