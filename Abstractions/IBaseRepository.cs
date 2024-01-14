using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeTracker.Abstractions
{
    public interface IBaseRepository<T> : IDisposable where T : TableData, new()
    {

        // Create/Update
        void SaveEntity(T entity, bool recursive = false);

        // Read One/Read Many
        T? GetEntity(int id);
        List<T>? GetEntities();

        // Delete
        void DeleteEntity(T entity);

    }
}
