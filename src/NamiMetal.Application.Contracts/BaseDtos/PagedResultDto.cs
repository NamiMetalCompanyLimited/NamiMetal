using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace NamiMetal.Application.Dtos
{
    public class PagedResultDto<T> : Volo.Abp.Application.Dtos.PagedResultDto<T>, IPagedResultRequest
    {
        public PagedResultDto() : base()
        {
        }

        public PagedResultDto(long totalCount, IReadOnlyList<T> items) : base(totalCount, items)
        {
        }

        public PagedResultDto(int skipCount, int maxResultCount, long totalCount, IReadOnlyList<T> items) : base(totalCount, items)
        {
            SkipCount = skipCount;
            MaxResultCount = maxResultCount;
        }

        public int PageCount { get => TotalCount > 0 ? (int)Math.Ceiling(TotalCount / (double)MaxResultCount) : 0; }
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
        public bool HasPreviousPage { get => SkipCount > 1; }
        public bool HasNextPage { get => SkipCount < PageCount; }
    }
}
