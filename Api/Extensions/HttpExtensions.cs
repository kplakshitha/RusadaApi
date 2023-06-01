using Api.Headers;
using System.Text.Json; 

namespace Api.Extensions
{
    public static class HttpExtensions
    {
        public static void AddpaginationHeader(this HttpResponse response, int skipCount, int itemsPerPage,
           int totalItems, int totalPages)
        {
            var paginationHeader = new PagnationHeader(skipCount, itemsPerPage, totalItems, totalPages);
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader, options));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
