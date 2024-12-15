using Domain.Entities;


namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : EntityBase;
        int Complete();
        void Dispose();
        void DatabaseRollback();
        void DatabaseCommit();
        ValueTask DisposeAsync();
        Task<int> CompleteAsync();
        Task<int> ExecuteSqlRawAsync(string Query);
    }
}
