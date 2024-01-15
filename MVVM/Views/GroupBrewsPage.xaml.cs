using FridgeTracker.MVVM.Models;

namespace FridgeTrackerZuyd.MVVM.Views;

public partial class GroupBrewsPage : ContentPage
{
	public GroupBrewsPage()
	{
		InitializeComponent();
	}

    private async void AddNewBrewGroup(object sender, EventArgs e)
    {
		int id = Int32.Parse(GroupId.Text);
		Group group = App.GroupRepo.GetEntity(id);
		await Navigation.PushAsync(new BrewCreatePage() { BindingContext = group });
    }
}