using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NewsApp.Models
{
    public static class NewsApiService
    {
        private static readonly string apiKey = "YOUR_API_KEY"; // Replace with your actual GNews API key

        public static async Task<List<NewsArticle>> FetchNewsByCategoryAsync(string category)
        {
            string url = $"https://gnews.io/api/v4/top-headlines?category={category}&lang=en&token={apiKey}";

            using var httpClient = new HttpClient();
            try
            {
                var response = await httpClient.GetStringAsync(url);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<NewsApiResponse>(response, options);
                return result?.Articles ?? new List<NewsArticle>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error fetching news: {ex.Message}");
                return new List<NewsArticle>();
            }
        }
    }
    public class NewsApiResponse
    {
        public required List<NewsArticle> Articles { get; set; } = new List<NewsArticle>();
    }

    public class NewsArticle
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Content { get; set; }
        public required string Url { get; set; }
        public required string Image { get; set; }
        public required DateTime PublishedAt { get; set; }
        public required NewsSource Source { get; set; }
    }

    public class NewsSource
    {
        public required string Name { get; set; }
        public required string Url { get; set; }
    }

}
