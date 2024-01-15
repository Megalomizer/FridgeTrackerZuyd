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
    [Table("GeneralUsers")]
    public class GeneralUser : TableData
    {
        [ManyToMany(typeof(GroupGeneralUser), CascadeOperations = CascadeOperation.All)]
        public List<Group>? Groups { get; set; }

        [Column("name"), Indexed]
        public string? Name { get; set; }
        
        [Unique]
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
