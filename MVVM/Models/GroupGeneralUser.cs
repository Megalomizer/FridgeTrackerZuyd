using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeTracker.MVVM.Models
{
    [Table("GroupGeneralUsers")]
    public class GroupGeneralUser
    {
        [ForeignKey(typeof(GeneralUser))]
        public int GeneralUserId { get; set; }

        [ForeignKey(typeof(Group))]
        public int GroupId { get; set; }
    }
}
