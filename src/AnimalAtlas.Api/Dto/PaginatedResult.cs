namespace AnimalAtlas.Api.Dto
{
    public class PaginatedResult
    {
        public int Page { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }
        public IEnumerable<object> Result { get; set; } = [];
    }
}
