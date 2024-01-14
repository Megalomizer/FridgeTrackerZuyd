using SQLiteNetExtensions.Attributes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeTracker.MVVM.Models
{
    public class GroupBrews
    {
        [ForeignKey(typeof(Group))]
        public int GroupId { get; set; }

        [ForeignKey(typeof(Brew))]
        public int BrewId { get; set; }
    }
}
