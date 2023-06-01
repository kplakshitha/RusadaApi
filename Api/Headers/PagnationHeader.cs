namespace Api.Headers
{
    public class PagnationHeader
    {
        public PagnationHeader(int skipCount, int itemsPerPage, int totalItems, int totalPages)
        {
            SkipCount = skipCount;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
            TotalPages = totalPages;
        }

        public int SkipCount { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}
