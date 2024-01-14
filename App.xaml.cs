using FridgeTrackerZuyd.MVVM.Views;
using FridgeTracker.Repositories;
using FridgeTracker.MVVM.Models;

namespace FridgeTrackerZuyd
{
    public partial class App : Application
    {
        public static BaseRepository<Brew>? BrewRepo { get; private set; }
        public static BaseRepository<GeneralUser>? UserRepo { get; private set; }
        public static BaseRepository<Group>? GroupRepo { get; private set; }

        public App(BaseRepository<Brew> brewRepo,
            BaseRepository<GeneralUser> userRepo,
            BaseRepository<Group> groupRepo)
        {
            InitializeComponent();

            BrewRepo = brewRepo;
            UserRepo = userRepo;
            GroupRepo = groupRepo;

            MainPage = new NavigationPage(new MainPage());
        }
    }
}
