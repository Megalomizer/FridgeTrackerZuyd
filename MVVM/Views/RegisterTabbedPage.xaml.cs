using FridgeTracker.MVVM.Models;
using FridgeTrackerZuyd;

namespace FridgeTracker.MVVM.Views
{
    public partial class RegisterTabbedPage : ContentPage
    {
        public RegisterTabbedPage()
        {
            InitializeComponent();
        }

        private async void CreateNewUser(object sender, EventArgs e)
        {
            string? email = EmailEntry.Text;
            string? p1 = PasswordEntry1.Text;
            string? p2 = PasswordEntry2.Text;

            if (email != "" || p1 != "" || p2 != "" && p1 == p2)
            {
                GeneralUser User = new GeneralUser
                {
                    Email = email,
                    Password = p1
                };

                App.UserRepo.SaveEntity(User);

                EmailEntry.Text = "";
            }
            else
            {
                await DisplayAlert("Incorrect Registry", "The credentials you have entered are incorrect. Please try again. Reminder: The passwords have to be the same and every field is required!", "Try Again");
            }

            PasswordEntry1.Text = "";
            PasswordEntry2.Text = "";
        }
    }
}