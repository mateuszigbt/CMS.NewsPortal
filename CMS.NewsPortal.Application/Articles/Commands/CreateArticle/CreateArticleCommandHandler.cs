using CMS.NewsPortal.Application.Common.Interfaces;
using CMS.NewsPortal.Domain.Entities;
using CMS.NewsPortal.Domain.Enums;
using CMS.NewsPortal.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CMS.NewsPortal.Application.Articles.Commands.CreateArticle
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, Guid>
    {
        private readonly IArticleRepository _repository;
        private readonly ISlugGenerator _slugGenerator;

        public CreateArticleCommandHandler(IArticleRepository repository, ISlugGenerator slugGenerator)
        {
            _repository = repository;
            _slugGenerator = slugGenerator;
        }

        public async Task<Guid> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var slug = await _slugGenerator.GenerateSlugAsync(request.Title);

            var article = new Article
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Content = request.Content,
                Author = request.Author,
                Slug = slug,
                Status = ArticleStatus.Draft,
                CreatedAt = DateTime.UtcNow,
            };

            await _repository.AddAsync(article);
            return article.Id;
        }
    }
}