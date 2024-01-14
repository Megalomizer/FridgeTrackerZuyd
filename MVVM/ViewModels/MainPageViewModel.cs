using FridgeTracker.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FridgeTrackerZuyd;

namespace FridgeTracker.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageViewModel
    {
        public List<Brew>? Brews { get; set; }
        public Brew? CurrentBrew { get; set; }
        public ICommand? AddOrUpdateCommand { get; set; }
        public ICommand? DeleteCommand { get; set; }

        public MainPageViewModel()
        { 
            AddOrUpdateCommand = new Command(async () =>
            {
                App.BrewRepo.SaveEntity(CurrentBrew);
                Console.WriteLine(App.BrewRepo.StatusMessage);
            });

            DeleteCommand = new Command(async () =>
            {
                App.BrewRepo.DeleteEntity(CurrentBrew);
            });
        }
    }
}
