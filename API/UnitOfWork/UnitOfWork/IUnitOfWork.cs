using Data.Context;
using Data.Models.Security;
using System;
using UnitOfWork.Repositories;
using UnitOfWork.Repositories.Locations.City;

namespace UnitOfWork.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        User CurrentUser { get; set; }
        ApplicationDbContext Context { get; }

        #region Repositories

        #region Locations
        public ICityRepository Cities { get; }
        #endregion

        #endregion

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        int Complete();
        void BeginTransaction();
        void RollBackTransaction();
        void CommitTransaction();
    }
}
