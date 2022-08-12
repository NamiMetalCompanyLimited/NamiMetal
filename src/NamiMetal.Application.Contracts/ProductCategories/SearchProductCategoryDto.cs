using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NamiMetal.ProductCategories
{
    public class SearchProductCategoryDto : PagedResultRequestDto
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool? Active { get; set; }
    }
}
