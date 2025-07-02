using Microsoft.Maui.Controls;
using NewsApp.Models;

namespace NewsApp.Pages;

public partial class NewsDetailPage : ContentPage
{
    public NewsDetailPage(Article article)
    {
        if (article == null)
            throw new ArgumentNullException(nameof(article));

        Title = "News Details";

        var imageControl = new Image
        {
            Source = article.Image ?? string.Empty,
            HeightRequest = 200,
            Aspect = Aspect.AspectFill,
            Margin = new Thickness(0, 0, 0, 16)
        };

        var titleLabel = new Label
        {
            Text = article.Title ?? "No Title",
            FontAttributes = FontAttributes.Bold,
            FontSize = 24,
            Margin = new Thickness(0, 0, 0, 8)
        };

        var contentLabel = new Label
        {
            Text = string.IsNullOrWhiteSpace(article.Content)
                ? article.Description
                : article.Content,
            FontSize = 16
        };

        Content = new ScrollView
        {
            Content = new VerticalStackLayout
            {
                Padding = 16,
                Children =
                {
                    imageControl,
                    titleLabel,
                    contentLabel
                }
            }
        };
    }
}
