using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Models { }
public class NewsApiResponse
{
    public List<NewsArticle> Articles { get; set; }
}

public class NewsArticle
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public string Url { get; set; }
    public string Image { get; set; }
    public DateTime PublishedAt { get; set; }
    public NewsSource Source { get; set; }
}

public class NewsSource
{
    public string Name { get; set; }
    public string Url { get; set; } = string.Empty; 
}
