using NewsApp.Models;

namespace NewsApp.Pages;

public partial class NewsDetailPage : ContentPage
{
    private Article _article;

    public NewsDetailPage(Article article)
    {
        InitializeComponent();
        _article = article;

        Title = "News Details";
        imageControl.Source = _article.Image; // Updated property name to match Article class
        titleLabel.Text = _article.Title;
        contentLabel.Text = _article.Content;
    }

    // Ensure these controls are defined in the XAML file and linked to the code-behind
    private Image imageControl; // Renamed to avoid ambiguity
    private Label titleLabel;
    private Label contentLabel;
}