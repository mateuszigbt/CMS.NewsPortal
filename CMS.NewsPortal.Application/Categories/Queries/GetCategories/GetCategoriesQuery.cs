using CMS.NewsPortal.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Application.Categories.Queries.GetCategories
{
    public record GetCategoriesQuery : IRequest<List<Category>>;
}