using CMS.NewsPortal.Application.Articles.Commands.UpdateArticle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Application.Common.Models.Articles
{
    public static class UpdateArticleDtoExtensions
    {
        public static UpdateArticleCommand ToCommand(this UpdateArticleDto dto, Guid id)
        {
            return new UpdateArticleCommand
            {
                Id = id,
                Title = dto.Title,
                Content = dto.Content,
                Author = dto.Author
            };
        }
    }
}