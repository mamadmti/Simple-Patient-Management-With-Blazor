﻿using Sureze.Domain.Contextes;
using Sureze.Domain.Contracts.Repositories;

namespace Sureze.Repositories
{
    public interface IRepositoryFactory
    {
        public IRepository Repository { get; }
        Task<int> SaveAsync();

    }
    public class RepositoryFactory :IDisposable, IRepositoryFactory
    {
        private ApplicationDbContext Db;

        public RepositoryFactory(ApplicationDbContext context, IRepository Repo)
        {
            Db = context;
            Repository = Repo;
        }

        public IRepository Repository { get; }
        public Task<int> SaveAsync()
        {
            var result = Db.SaveChangesAsync();
            return result;
        }

        private bool disposed = false;
        
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
