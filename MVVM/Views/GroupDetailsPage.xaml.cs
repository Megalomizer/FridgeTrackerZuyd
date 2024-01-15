using FridgeTracker.MVVM.Models;
using Microsoft.Maui.Graphics.Text;

namespace FridgeTrackerZuyd.MVVM.Views;

public partial class GroupDetailsPage : ContentPage
{
	public GroupDetailsPage()
	{
		InitializeComponent();
	}

    private async void DeleteGroup(object sender, EventArgs e)
    {
		int id = Int32.Parse(GroupId.Text);
		Group group = App.GroupRepo.GetEntity(id);

		string destruction = "Delete";
		string result = await DisplayActionSheet("Are you sure you want to delete this group?", "Keep", destruction);
		if (result == destruction)
		{
			App.GroupRepo.DeleteEntity(group);
		};
    }
}