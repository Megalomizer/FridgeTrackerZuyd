using FridgeTracker.Abstractions;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeTracker.MVVM.Models
{
    public class Brew : TableData
    {
        [ManyToMany(typeof(GroupBrews), CascadeOperations = CascadeOperation.All)]
        public List<Group>? Groups {  get; set; } 

        public string? Name { get; set; }
        public string? Description { get; set; }
        public int BrewsLeft { get; set; }
    }
}
