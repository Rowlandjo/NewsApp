using NewsApp.Models; 

namespace NewsApp.Pages;

public partial class NewsListPage : ContentPage
{
    private string category;

    public NewsListPage(string category)
    {
        InitializeComponent();
        this.category = category;
        Title = category;
        LoadNewsArticles(category);
    }

    private async void OnArticleTapped(object sender, SelectionChangedEventArgs e)
    {
        var selectedArticle = e.CurrentSelection.FirstOrDefault() as NewsArticle;
        if (selectedArticle != null)
        {
            await Navigation.PushAsync(new NewsDetailPage(selectedArticle));
        }
    }
}