using Data.Context;
using Data.Models.Locations;
using Data.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using UnitOfWork.Repositories;
using UnitOfWork.Repositories.Locations.City;
using UnitOfWork.Repositories.Locations.CityRepository;

namespace UnitOfWork.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public User CurrentUser { get; set; }
        private IDbContextTransaction DbContextTransaction { get; set; }
        private Dictionary<Type, object> repositories;

        #region Repositories

        #region Locations
        public ICityRepository Cities { get => new CityRepository(Context); }
        #endregion

        #endregion

        public UnitOfWork()
        {
            Context = new ApplicationDbContext();
        }

        #region Methods
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (repositories == null)
                repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
            {
                repositories[type] = new Repository<ApplicationDbContext, TEntity>(Context);
            }

            return (IRepository<TEntity>)repositories[type];
        }

        public ApplicationDbContext Context { get; }

        public void BeginTransaction()
        {
            DbContextTransaction = Context.Database.BeginTransaction(IsolationLevel.Serializable);
        }

        public void RollBackTransaction()
        {
            DbContextTransaction.Rollback();
            DbContextTransaction.Dispose();
        }

        public void CommitTransaction()
        {
            DbContextTransaction.Commit();
            DbContextTransaction.Dispose();
        }

        public int Complete()
        {
            return Context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
