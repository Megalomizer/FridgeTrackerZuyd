using FridgeTracker.MVVM.Models;
using FridgeTracker.MVVM.Views;

namespace FridgeTrackerZuyd.MVVM.Views;

public partial class GroupCreatePage : ContentPage
{
	public GroupCreatePage()
	{
		InitializeComponent();
	}

    private void CreateNewGroup(object sender, EventArgs e)
    {
		Group group = new Group
		{
			Name = GroupName_ent.Text,
			Creator = App.UserRepo.GetEntity(App.LoggedInUser.Id),
			GroupCreator = App.LoggedInUser.Id
		};
		// Save the new group
		App.GroupRepo.SaveEntity(group);

		//Update user to have this in his list
		GeneralUser user = App.UserRepo.GetEntity(group.GroupCreator);
		if(user.Groups == null)
		{
			user.Groups = new List<Group>();
		}
		user.Groups.Add(group);
		App.UserRepo.SaveEntity(user);

		GroupName_ent.Text = "";

		Navigation.PopAsync();
    }
}