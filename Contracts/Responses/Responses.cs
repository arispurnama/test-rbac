namespace ApiCrud.Contracts.Responses
{
    public class Responses
    {
        public bool Errored { get; set; }
        public string ErrorMessage { get; set; }
    }
    public sealed class PaginationResponse<TReturn> : Responses
    {
        public int Total { get; set; }
        public List<TReturn> Data { get; set; }
    }
}
