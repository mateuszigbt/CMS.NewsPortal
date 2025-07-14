using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CMS.NewsPortal.Application.Articles.Commands.CreateArticle
{
    public class UpdateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        public UpdateArticleCommandValidator() 
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required");

            RuleFor(x => x.Content)
                .Cascade(CascadeMode.Stop)
                .Must(c => c.Trim().Length > 9)
                .WithMessage("Content must be at least 10 characters");
        }
    }
}