using NewsApp.Models;

namespace NewsApp.Pages;

public partial class NewsListPage : ContentPage
{
    private readonly string _category;

    public NewsListPage(string category)
    {
        InitializeComponent(); 
        _category = category;

        if (OperatingSystem.IsWindows())
        {
            Title = char.ToUpper(category[0]) + category.Substring(1);
        }

        LoadNewsArticles();
    }

    private async void LoadNewsArticles()
    {
        try
        {
            var articles = await NewsApiService.FetchNewsByCategoryAsync(_category);

            if (articles?.Any() == true)
            {
                var newsCollectionView = FindByName("NewsCollectionView") as CollectionView;
                if (newsCollectionView != null)
                {
                    newsCollectionView.ItemsSource = articles;
                }
            }
            else
            {
                await DisplayAlert("Notice", "No articles found for this category.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Failed to load news articles.", "OK");
            System.Diagnostics.Debug.WriteLine($"Error fetching articles: {ex.Message}");
        }
    }

    private async void OnArticleTapped(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is NewsArticle selectedArticle)
        {
            var article = new Article
            {
                Title = selectedArticle.Title,
                Description = selectedArticle.Description,
                Content = selectedArticle.Content,
                Url = selectedArticle.Url,
                Image = selectedArticle.Image, 
                PublishedAt = selectedArticle.PublishedAt,
                Source = new Source
                {
                    Name = selectedArticle.Source.Name,
                    Url = selectedArticle.Source.Url
                }
            };

            await Navigation.PushAsync(new NewsDetailPage(article));

            var newsCollectionView = FindByName("NewsCollectionView") as CollectionView;
            if (newsCollectionView != null)
            {
                newsCollectionView.SelectedItem = null;
            }
        }
    }
}
