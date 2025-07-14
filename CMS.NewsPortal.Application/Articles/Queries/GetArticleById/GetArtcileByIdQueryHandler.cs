using CMS.NewsPortal.Application.Articles.Queries.GetArticles;
using CMS.NewsPortal.Application.Common.Exceptions;
using CMS.NewsPortal.Application.Common.Models.Articles;
using CMS.NewsPortal.Domain.Entities;
using CMS.NewsPortal.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Application.Articles.Queries.GetArticleById
{
    public class GetArtcileByIdQueryHandler : IRequestHandler<GetArtcileByIdQuery, GetArticlesDto?>
    {
        private readonly IArticleRepository _artRepo;
        private readonly ICategoryRepository _catRepo;

        public GetArtcileByIdQueryHandler(IArticleRepository artRepo, ICategoryRepository catRepo)
        {
            _artRepo = artRepo;
            _catRepo = catRepo;
        }

        public async Task<GetArticlesDto?> Handle(GetArtcileByIdQuery query, CancellationToken cancellationToken)
        {
            var article = await _artRepo.GetByIdAsync(query.Id) ?? throw new NotFoundException("Article not found");

            if (article is null)
            {
                return null;
            }

            var categories = (await _catRepo.GetAllAsync()).ToDictionary(c => c.Id, c => c.Name);

            return article.ToDto(categories);
        }
    }
}