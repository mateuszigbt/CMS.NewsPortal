using CMS.NewsPortal.Application.Common.Exceptions;
using CMS.NewsPortal.Domain.Enums;
using CMS.NewsPortal.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Application.Articles.Commands.PublishArticle
{
    public class PublishArticleCommandHandler : IRequestHandler<PublishArticleCommand, Unit>
    {
        private readonly IArticleRepository _repository;

        public PublishArticleCommandHandler(IArticleRepository repository) 
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(PublishArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await _repository.GetByIdAsync(request.Id) ?? throw new NotFoundException("Article not found");

            article.Status = ArticleStatus.Published;
            await _repository.UpdateAsync(article);
            return Unit.Value;
        }
    }
}