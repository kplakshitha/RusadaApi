namespace Business.Models
{
    public class AircraftParams
    {
        private const int MaxPageSize = 50;
        public int Skip { get; set; }
        public string? Search { get; set; }

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}
