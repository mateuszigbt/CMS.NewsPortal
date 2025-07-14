using CMS.NewsPortal.Application.Common.Interfaces;
using CMS.NewsPortal.Domain.Repositories;
using CMS.NewsPortal.Domain.Services;
using CMS.NewsPortal.Infrastructure.Data;
using CMS.NewsPortal.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IArticleStatsService, ArticleStatsService>();
            services.AddScoped<ISlugGenerator, SlugGenerator>();
            services.AddScoped<IArticleRepository, EfArticleRepository>();
            services.AddScoped<ICategoryRepository, EfCategoryRepository>();

            return services;
        }
    }
}