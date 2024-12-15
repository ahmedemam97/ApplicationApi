using Application.Interfaces;
using DataAccess;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections;


namespace Application.Implement
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly ApplicationDBContext _context;
        public UnitOfWork(ApplicationDBContext context)
        {

            _context = context;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void DatabaseRollback()
        {
            _context.Database.BeginTransaction().Rollback();
        }
        public void DatabaseCommit()
        {
            _context.Database.BeginTransaction().Commit();
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
        public async Task<int> ExecuteSqlRawAsync(string Query)
        {
            return await _context.Database.ExecuteSqlRawAsync(Query);
        }
        public IGenericRepository<T> Repository<T>() where T : EntityBase
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (IGenericRepository<T>)_repositories[type];
        }
    }
}
