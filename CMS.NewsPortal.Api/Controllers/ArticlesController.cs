using CMS.NewsPortal.Application.Articles.Commands.CreateArticle;
using CMS.NewsPortal.Application.Articles.Commands.PublishArticle;
using CMS.NewsPortal.Application.Articles.Commands.UpdateArticle;
using CMS.NewsPortal.Application.Articles.Queries.GetArticleById;
using CMS.NewsPortal.Application.Articles.Queries.GetArticles;
using CMS.NewsPortal.Application.ArticlesStats.Queries;
using CMS.NewsPortal.Application.Common.Models.Articles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMS.NewsPortal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticlesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>Create a new article (default status <c>Draft</c>).</summary>
        /// <remarks>
        ///     Requires non‑empty <c>title</c> and <c>content</c> of at least 10 characters.
        /// </remarks>
        /// <param name="command">
        ///     Object containing the create values (<see cref="CreateArticleCommand"/>).
        /// </param>
        /// <response code="201">Returns the ID of the newly created article.</response>
        /// <response code="400">Validation failed.</response>
        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { articleId = id }, null);
        }

        /// <summary>
        ///     Get article details.
        /// </summary>
        /// <param name="articleId">
        ///     Identifactor of article
        /// </param>
        /// <response code="200">Return article</response>
        /// <response code="404">Article is not exist</response>
        [HttpGet("{articleId:guid}")]
        public async Task<IActionResult> GetById(Guid articleId)
        {
            var article = await _mediator.Send(new GetArtcileByIdQuery(articleId));
            return article is null ? NotFound() : Ok(article);
        }

        /// <summary>
        ///     Get a list of articles.
        /// </summary>
        /// <param name="status">
        ///     Optional filter: <c>Draft</c> or <c>Published</c>).
        /// </param>
        /// <response code="200">Succesfully returns list of articles.</response>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? status)
        {
            var list = await _mediator.Send(new GetArticlesQuery(status));
            return Ok(list);
        }

        /// <summary>
        ///     Update an article.
        /// </summary>
        /// <param name="articleId">
        ///     Identifier of the article to update (GUID in route).
        /// </param>
        /// <param name="dto">
        ///     Object containing the updated values (<see cref="UpdateArticleDto"/>).
        /// </param>
        /// <response code="200">Succesfully updated</response>
        /// <response code="400">Validation failed</response>
        /// <response code="404">Article is not exist</response>
        [HttpPut("{articleId:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid articleId, [FromBody] UpdateArticleDto dto)
        {
            var command = dto.ToCommand(articleId);
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        ///     Publish an article (changes status to <c>Published</c>).
        /// </summary>
        /// <param name="articleId">
        ///     Identifactor of article
        /// </param>
        /// <response code="200">Succesfully published</response>
        /// <response code="404">Article is not exist</response>
        [HttpPost("{articleId:guid}/publish")]
        public async Task<IActionResult> Publish([FromRoute] Guid articleId)
        {
            await _mediator.Send(new PublishArticleCommand(articleId));
            return Ok();
        }

        /// <summary>
        ///     Get article statistics (number of drafts, published articles, most used category).
        /// </summary>
        /// <response code="200">Succesfully returns list of stats</response>
        [HttpGet("stats")]
        public async Task<IActionResult> GetStats()
        {
            var stats = await _mediator.Send(new GetArticleStatsQuery());
            return Ok(stats);
        }

    }
}