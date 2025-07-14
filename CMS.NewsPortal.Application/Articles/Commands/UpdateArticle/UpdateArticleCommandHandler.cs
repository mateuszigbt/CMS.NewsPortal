using CMS.NewsPortal.Application.Common.Exceptions;
using CMS.NewsPortal.Application.Common.Interfaces;
using CMS.NewsPortal.Domain.Enums;
using CMS.NewsPortal.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Application.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, Unit>
    {
        private readonly IArticleRepository _repository;
        private readonly ISlugGenerator _slugGenerator;

        public UpdateArticleCommandHandler(IArticleRepository repo, ISlugGenerator slugGenerator)
        {
            _repository = repo;
            _slugGenerator = slugGenerator;
        }

        public async Task<Unit> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await _repository.GetByIdAsync(request.Id) ?? throw new NotFoundException("Article not found");

            if (!string.Equals(article.Title, request.Title, StringComparison.Ordinal))
            {
                article.Slug = await _slugGenerator.GenerateSlugAsync(request.Title);
            }

            article.Title = request.Title;
            article.Content = request.Content;
            article.Author = request.Author;

            await _repository.UpdateAsync(article);
            return Unit.Value;
        }
    }
}