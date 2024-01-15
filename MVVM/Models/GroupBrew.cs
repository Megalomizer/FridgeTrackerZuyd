using SQLiteNetExtensions.Attributes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeTracker.MVVM.Models
{
    [Table("GroupBrews")]
    public class GroupBrew
    {
        [ForeignKey(typeof(Group))]
        public int GroupId { get; set; }

        [ForeignKey(typeof(Brew))]
        public int BrewId { get; set; }
    }
}
