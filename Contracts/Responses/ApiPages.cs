using ApiCrud.Contracts.Requests;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Contracts.Responses
{
   public sealed class ApiPages<T>
    {
        public ApiPages(int total, int page, int limit, IReadOnlyCollection<T> data)
        {
            Total = total;
            Page = page;
            Limit = limit;
            Data = data;
        }

        public int Total { get; init; }
        public int Page { get; init; }
        public int Limit { get; init; } 
        public IEnumerable<T> Data { get; init; } = null!;
        public bool HasNext => (Page * Limit) < Total;
        public bool HasPrev => Page > 1;
        public static async Task<ApiPages<T>> CreateAsync(IQueryable<T> query, PageRequest req, CancellationToken ct = default)
        {
            var data = await query.Skip(req.Skip).Take(req.PageSize).ToListAsync(ct);
            int total = await query.CountAsync(ct);
            return new ApiPages<T>(total, req.PageCount, req.PageSize, data);
        }
    }
    public sealed class ApiPages
    {
        public ApiPages(int total, int page, int limit, IEnumerable<object> data)
        {
            Total = total;
            Page = page;
            Data = data;
            Limit = limit;
        }

        public int Total { get; init; }
        public int Page { get; init; }
        public int Limit { get; init; }
        public IEnumerable<object> Data { get; init; } = null!;
        public static async Task<ApiPages> CreateAsync<T>(IQueryable<T> query, PageRequest req)
        {
            int total = await query.CountAsync();
            var data = await query.Skip(req.Skip).Take(req.PageSize).ToListAsync();
            return new ApiPages(total, req.PageCount, req.PageSize, data.Cast<object>());
        }
    }
    public sealed class ApiSingleResponse<TReturn>
    {
        public TReturn data { get; set; }
    }
}
