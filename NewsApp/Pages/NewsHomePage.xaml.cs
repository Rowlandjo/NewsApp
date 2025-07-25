using Microsoft.Maui.Controls;
using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsHomePage : ContentPage
{
	public List<Article> ArticleList;
    public List<Category> CategoryList = new List<Category>()
    {
        new Category(){Name="World", ImageUrl = "world.png"},
        new Category(){Name = "Nation" , ImageUrl="nation.png"},
        new Category(){Name = "Business" , ImageUrl="business.png"},
        new Category(){Name = "Technology" , ImageUrl="technology.png"},
        new Category(){Name = "Entertainment", ImageUrl = "entertainment.png"},
        new Category(){Name = "Sports" , ImageUrl="sports.png"},
        new Category(){Name = "Science", ImageUrl= "science.png"},
        new Category(){Name = "Health", ImageUrl="health.png"},
    };
    public NewsHomePage()
	{
		InitializeComponent();
        ArticleList = new List<Article>();
        CvCategories.ItemsSource = CategoryList;
        _ = GetBreakingNews(); 
	}
	private async Task GetBreakingNews()
	{
		var apiService = new ApiService();
		var newsResult = await apiService.GetNews("Sports");
		foreach (var item in newsResult.Articles)
		{
			ArticleList.Add(new Article
			{
				Title = item.Title,
				Description = item.Description,
				Content = item.Content,
				Url = item.Url,
				Image = item.Image,
				PublishedAt = item.PublishedAt,
				Source = item.Source
			});
		}
		CvNews.ItemsSource = ArticleList; // Ensure CvNews is defined in the XAML file
	}
    private async void OnCategorySelected(object sender, SelectionChangedEventArgs e)
    {
        var selectedCategory = e.CurrentSelection.FirstOrDefault() as Category;
        if (selectedCategory != null)
        {
            string categoryParam = selectedCategory.Name.ToLower();
            await Navigation.PushAsync(new NewsListPage(categoryParam));
        }

    ((CollectionView)sender).SelectedItem = null;
    }
}