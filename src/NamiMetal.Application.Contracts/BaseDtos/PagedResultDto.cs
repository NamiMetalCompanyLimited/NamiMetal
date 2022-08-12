using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NamiMetal.Application.Dtos
{
    public class PagedResultDto<T> : Volo.Abp.Application.Dtos.PagedResultDto<T>, IPagedResultRequest
    {
        public PagedResultDto() : base()
        {
            OrderNum = (SkipCount - 1) * MaxResultCount + 1;
        }

        public PagedResultDto(long totalCount, IReadOnlyList<T> items) : base(totalCount, items)
        {
            OrderNum = (SkipCount - 1) * MaxResultCount + 1;
        }

        public PagedResultDto(int skipCount, int maxResultCount, long totalCount, IReadOnlyList<T> items) : base(totalCount, items)
        {
            SkipCount = skipCount;
            MaxResultCount = maxResultCount;
            OrderNum = (SkipCount - 1) * MaxResultCount + 1;
        }

        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
        public bool HasPreviousPage { get => SkipCount > 1; }
        public bool HasNextPage { get => SkipCount < TotalCount; }
        public long OrderNum { get; set; }
    }
}
