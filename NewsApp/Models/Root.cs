using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Models
{
    public class Article
    {
        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty; // Default value added

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty; // Default value added

        [JsonProperty("content")]
        public string Content { get; set; } = string.Empty; // Default value added

        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty; // Default value added

        [JsonProperty("image")]
        public string Image { get; set; } = string.Empty; // Default value added

        [JsonProperty("publishedAt")]
        public DateTime PublishedAt { get; set; }

        [JsonProperty("source")]
        public Source Source { get; set; } = new Source(); // Default value added
    }

    public class Root
    {
        [JsonProperty("totalArticles")]
        public int TotalArticles { get; set; }

        [JsonProperty("articles")]
        public List<Article> Articles { get; set; } = new List<Article>(); // Default value added
    }

    public class Source
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty; // Default value added

        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty; // Default value added
    }
}
