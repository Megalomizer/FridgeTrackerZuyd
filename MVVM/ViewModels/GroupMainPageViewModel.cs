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
            Groups = GetGroupsByUser(App.LoggedInUser);
        }

        // Get list of groups with a user
        private List<Group>? GetGroupsByUser(GeneralUser entity)
        {
            List<Group> g = App.GroupRepo.GetEntities();
            List<Group> groups = new List<Group>();

            foreach (Group group in g)
            {
                if (group.Creator == entity || group.GroupCreator == entity.Id || group.Members.Contains(entity))
                {
                    if (group.GroupCreator == entity.Id)
                        group.Creator = entity;
                    groups.Add(group);
                }
            }

            return groups;
        }
    }
}
