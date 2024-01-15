using FridgeTracker.Abstractions;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions;
using SQLite;

namespace FridgeTracker.MVVM.Models
{
    [Table("Groups")]
    public class Group : TableData
    {
        [ManyToMany(typeof(GroupBrew), CascadeOperations = CascadeOperation.All)]
        public List<Brew>? Brews { get; set; }

        [ManyToMany(typeof(GroupGeneralUser),CascadeOperations = CascadeOperation.All)]
        public List<GeneralUser>? Members { get; set; }

        [OneToOne(CascadeOperations=CascadeOperation.All)]
        public GeneralUser? Creator { get; set; }

        [ForeignKey(typeof(GeneralUser))]
        public int GroupCreator {  get; set; }

        public string? Name { get; set; }
    }
}
