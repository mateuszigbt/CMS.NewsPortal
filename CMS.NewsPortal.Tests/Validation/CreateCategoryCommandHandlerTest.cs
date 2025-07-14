using CMS.NewsPortal.Application.Categories.Commands.CreateCategory;
using CMS.NewsPortal.Application.Common.Exceptions;
using CMS.NewsPortal.Domain.Entities;
using CMS.NewsPortal.Domain.Repositories;
using CMS.NewsPortal.Infrastructure.Data;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Tests.Validation
{
    public class CreateCategoryCommandHandlerTest
    {
        [Fact]
        public async Task DuplicateNameShouldThrowBadRequest()
        {
            ICategoryRepository repo = new EfCategoryRepository();
            await repo.AddAsync(new Category { Id = Guid.NewGuid(), Name = "World" });

            var handler = new CreateCategoryCommandHandler(repo);

            Func<Task> act = () => handler.Handle(
                new CreateCategoryCommand { Name = "World" },
                CancellationToken.None);

            await act.Should().ThrowAsync<BadRequestException>()
                .WithMessage("*unique*");
        }
    }
}