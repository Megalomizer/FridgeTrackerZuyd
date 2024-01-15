using FridgeTracker.MVVM.Models;
using FridgeTrackerZuyd.MVVM.ViewModels;
using FridgeTrackerZuyd.MVVM.Views;

namespace FridgeTracker.MVVM.Views;

public partial class GroupMainPage : ContentPage
{
	public GroupMainPage()
	{
		InitializeComponent();
        BindingContext = new GroupMainPageViewModel();
	}

    // Go to Home
    private async void Toolbar_Home_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Homepage());
    }

    // Go to Groups
    private async void Toolbar_Groups_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GroupMainPage());
    }

    // Go to Profile
    private async void Toolbar_Profile_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProfileMainPage());
    }

    private async void CreateGroup_nav(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GroupCreatePage());
    }

    private void JoinGroup_nav(object sender, EventArgs e)
    {
        //await Navigation.PushAsync();
    }

    private void ViewCell_Tapped(object sender, EventArgs e)
    {
        var viewCell = sender as ViewCell;
        var tappedItem = viewCell.BindingContext as Group;

        Navigation.PushAsync(new GroupDetailsTabbedPage() { BindingContext = tappedItem });
    }
}