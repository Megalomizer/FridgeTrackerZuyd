using Plugin.LocalNotification;

namespace FridgeTrackerZuyd.MVVM.Views;

public partial class MobileFunctions : ContentPage
{
	public MobileFunctions()
	{
		InitializeComponent();
	}

    private async void SendNotification(object sender, EventArgs e)
    {
        // Check for notification permissions
        if (!await LocalNotificationCenter.Current.AreNotificationsEnabled())
            await LocalNotificationCenter.Current.RequestNotificationPermission();

        // Make a notification request
        var request = new NotificationRequest
        {
            NotificationId = 1337,
            Title = "Test Notification",
            Subtitle = "This is a subtitle",
            Description = "AAAHHH THIS IS A DEScripTION",
            BadgeNumber = 42,
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Now.AddSeconds(5),
            }
        };

        await LocalNotificationCenter.Current.Show(request);
    }

    private async void TakePhoto(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
                string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                using Stream sourceStream = await photo.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);

                await sourceStream.CopyToAsync(localFileStream);

                TakenPicture_img.Source = localFilePath;
            }
        }
    }

    private async void RemovePhoto(object sender, EventArgs e)
    {
        TakenPicture_img.Source = null;
    }

    private async void AddCameraRollPhoto(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.Default.PickPhotoAsync();

            if (photo != null)
            {
                string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                using Stream sourceStream = await photo.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);

                await sourceStream.CopyToAsync(localFileStream);

                TakenPicture_img.Source = localFilePath;
            }
        }
    }

    private void GenerateQR(object sender, EventArgs e)
    {

    }
}