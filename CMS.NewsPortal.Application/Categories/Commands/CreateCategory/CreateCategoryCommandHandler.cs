using CMS.NewsPortal.Application.Common.Exceptions;
using CMS.NewsPortal.Domain.Entities;
using CMS.NewsPortal.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _repo;

        public CreateCategoryCommandHandler(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            if (await _repo.ExistsByNameAsync(command.Name))
            {
                throw new BadRequestException("Category must be unique");
            }

            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
            };

            await _repo.AddAsync(category);
            return category.Id;
        }
    }
}