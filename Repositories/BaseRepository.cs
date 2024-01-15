using FridgeTracker.Abstractions;
using FridgeTracker.MVVM.Models;
using FridgeTracker.MVVM.Views;
using FridgeTrackerZuyd;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeTracker.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : TableData, new()
    {
        SQLiteConnection connection;
        public string? StatusMessage { get; set; }

        public BaseRepository()
        {
            connection = new SQLiteConnection(Constants.DatabasePath, Constants.flags);
            connection.CreateTable<T>();

            // Create all tables -> Anders foutmeldingen van koppeltabellen
            connection.CreateTables<Brew, Group, GeneralUser, GroupBrew, GroupGeneralUser>();
        }

        // Create/Update
        public void SaveEntity(T? entity, bool recursive = false)
        {
            if(entity != null)
            {
                try
                {
                    try
                    {
                        if (entity.Id != 0)
                            connection.UpdateWithChildren(entity);
                        else
                            connection.InsertWithChildren(entity);
                    }
                    catch (Exception ex)
                    {
                        if (entity.Id != 0)
                            connection.Update(entity);
                        else
                            connection.Insert(entity);
                    }
                }
                catch (Exception ex)
                {
                    StatusMessage = $"Error: {ex.Message}";
                }
            }
        }

        // Read One
        public T? GetEntity(int id)
        {
            try
            {
                T entity = new T();
                try
                {
                    entity = connection.GetWithChildren<T>(id);
                }
                catch (Exception e)
                {
                    entity = connection.Table<T>().FirstOrDefault(t => t.Id == id);
                }
                
                return entity;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }

            return null;
        }

        // Read Many
        public List<T>? GetEntities()
        {
            try
            {
                List<T> entity = new List<T>();
                try
                {
                    entity = connection.GetAllWithChildren<T>().ToList();
                }
                catch (Exception ex)
                {
                    entity = connection.Table<T>().ToList();
                }
                return entity;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        // Delete
        public void DeleteEntity(T entity)
        {
            try
            {
                connection.Delete(entity);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        // Dispose is extra vanuit de IDisposable interface
        // Het sluit de connectie om rescources te besparen
        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
