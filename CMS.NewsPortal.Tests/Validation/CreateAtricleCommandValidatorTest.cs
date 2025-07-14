using CMS.NewsPortal.Application.Articles.Commands.CreateArticle;
using CMS.NewsPortal.Domain.Entities;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Tests.Validation
{
    public class CreateAtricleCommandValidatorTest
    {
        private readonly UpdateArticleCommandValidator _validator = new UpdateArticleCommandValidator();

        [Fact]
        public void EmptyTitleShouldFailValidation()
        {
            var command = new CreateArticleCommand
            {
                Title = "",
                Content = "1234567890",
                Author = "Mateusz"
            };

            var result = _validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(c => c.Title);
        }
    }
}