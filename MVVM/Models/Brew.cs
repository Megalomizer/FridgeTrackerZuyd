using FridgeTracker.Abstractions;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeTracker.MVVM.Models
{
    [Table("Brews")]
    public class Brew : TableData
    {
        [ManyToMany(typeof(GroupBrew), CascadeOperations = CascadeOperation.All)]
        public List<Group>? Groups {  get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public int BrewsLeft { get; set; }
    }
}
