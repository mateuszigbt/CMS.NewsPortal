using CMS.NewsPortal.Application.Categories.Commands.CreateCategory;
using CMS.NewsPortal.Application.Categories.Queries.GetCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMS.NewsPortal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        /// <summary>
        ///     Get a list of all categories.
        /// </summary>
        /// <response code="200">Successfully returns a list of categories.</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _mediator.Send(new GetCategoriesQuery());
            return Ok(list);
        }

        /// <summary>
        ///     Creates a new category.
        /// </summary>
        /// <param name="command">
        ///     Object containing the create values (<see cref="CreateCategoryCommand"/>).
        /// </param>
        /// <response code="201">Returns the location of the newly created category.</response>
        /// <response code="400">Validation failed.</response>
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            var id = await _mediator.Send(command);
            return Created($"/api/categories/{id}", null);
        }
    }
}