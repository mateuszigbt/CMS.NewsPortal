﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MediatR;

namespace CMS.NewsPortal.Application.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommand : IRequest<Unit>
    {
        public Guid Id {  get; set; }
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public string Author { get; set; } = default!;
    }
}