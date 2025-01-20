namespace ApiCrud.Contracts.Requests;
public class PageRequest
{
    public int? Limit { get; init; }
    public int? Page { get; init; }
    public string? Sorts { get; init; }
    public string? Searches { get; init; }
    public string? Includes { get; init; }
    public int PageCount => Page is null || Page < 0 ? 0 : 0 + (Page ?? 0);
    public int PageSize => Limit is null || Limit < 1 ? 10 : (Limit ?? 10);
    public int Skip => PageCount * PageSize;

}
