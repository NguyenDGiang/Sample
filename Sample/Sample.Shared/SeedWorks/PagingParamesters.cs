namespace Sample.Shared.SeedWorks
{
    public class PagingParamesters
    {
        private const int maxPaging = 50;
        private int _pagingSize = 10;
        public int PagingSize
        {
            get => _pagingSize; set => _pagingSize = (value > maxPaging) ? maxPaging : value;
        }
        public int PageNumber { get; set; } = 1;
    }
}
