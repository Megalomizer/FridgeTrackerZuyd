using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FridgeTracker.MVVM.Models;

namespace FridgeTrackerZuyd.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class GroupMainPageViewModel
    {
        public List<Group>? Groups { get; set; }

        public GroupMainPageViewModel()
        {
            Groups = App.GroupRepo.GetGroupsByUser(App.LoggedInUser);
        }
    }
}
