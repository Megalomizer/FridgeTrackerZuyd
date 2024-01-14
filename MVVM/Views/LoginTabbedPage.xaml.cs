using FridgeTracker.MVVM.Models;
using FridgeTrackerZuyd;

namespace FridgeTracker.MVVM.Views;

public partial class LoginTabbedPage : ContentPage
{
	public LoginTabbedPage()
	{
		InitializeComponent();
	}

    /// <summary>
    /// Check credentials and log user in
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        string userEmail = EmailEntry.Text;
        string userPassword = PasswordEntry.Text;

        if (userEmail == "" || userPassword == "")
        {
            await DisplayAlert("Incorrect input", "You have not entered all information.\nPlease try again.", "OK");
            EmailEntry.Text = "";
            PasswordEntry.Text = "";
            return;
        }

        // Get all users and find the corresponding email & password combination
        List<GeneralUser>? users = App.UserRepo.GetEntities();
        if (users == null || users.Count == 0)
            await DisplayAlert("No accounts found", "There was no account found with these login credentials. Please register first.", "OK");
        else
        {
            foreach (GeneralUser user in users)
            {
                if (user.Email == userEmail && user.Password == userPassword)
                {
                    await Navigation.PushAsync(new Homepage());
                    EmailEntry.Text = "";
                }
                else if (user.Email != userEmail || user.Password != userPassword)
                {
                    await DisplayAlert("Incorrect credentials", "There was no account found with these login credentials. Please register or fill in the correct information.", "OK");
                }
            }
        }

        // Reset password
        PasswordEntry.Text = "";
    }
}