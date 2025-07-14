using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.NewsPortal.Application.Common.Interfaces
{
    public interface ISlugGenerator
    {
        Task<string> GenerateSlugAsync(string title);
    }
}