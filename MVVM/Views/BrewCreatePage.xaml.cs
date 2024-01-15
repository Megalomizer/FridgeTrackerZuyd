using FridgeTracker.MVVM.Models;

namespace FridgeTrackerZuyd.MVVM.Views;

public partial class BrewCreatePage : ContentPage
{
	public BrewCreatePage()
	{
		InitializeComponent();
	}

    private async void SaveBrew_btn_Clicked(object sender, EventArgs e)
    {
		int id = Int32.Parse(GroupId.Text);
		Group group = App.GroupRepo.GetEntity(id);

		Brew brew = new Brew
		{
			Name = name_entry.Text,
			Description = description_Entry.Text,
			BrewsLeft = Int32.Parse(brewlimit_entry.Text),
			Groups = new List<Group> { group }
		};

		App.BrewRepo.SaveEntity(brew);
		if (group.Brews == null)
			group.Brews = new List<Brew>();
		group.Brews.Add(brew);
		App.GroupRepo.SaveEntity(group);
		await Navigation.PopAsync();
    }
}