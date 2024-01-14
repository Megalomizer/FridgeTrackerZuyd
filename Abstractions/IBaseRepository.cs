using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FridgeTracker.MVVM.Models;

namespace FridgeTracker.Abstractions
{
    public interface IBaseRepository<T> : IDisposable where T : TableData, new()
    {

        // Create/Update
        void SaveEntity(T entity, bool recursive = false);

        // Read One/Read Many
        T? GetEntity(int id);
        List<T>? GetEntities();

        // Get Group by user
        List<Group>? GetGroupsByUser(GeneralUser entity);

        // Delete
        void DeleteEntity(T entity);

    }
}
