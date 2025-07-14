using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Domain.Entities
{
    public class ArticleStats
    {
        public int PublishedCount { get; }
        public int DraftCount { get; }
        public string? MostUsedCategory { get; }

        public ArticleStats(int publishedCount, int dratfCount, string? mostUsedCategory)
        {
            PublishedCount = publishedCount;
            DraftCount = dratfCount;
            MostUsedCategory = mostUsedCategory;
        }
    }
}