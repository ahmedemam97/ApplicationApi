using Domain.Dto;
using Domain.Entities;
using System.Linq.Expressions;


namespace Application.Interfaces
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        bool Add(T entity);
        bool AddRange(IEnumerable<T> entity);
        Task<ResponseResult> UpdateAsync(T entity);
        bool Remove(T entity);
        IQueryable<T> Where(Expression<Func<T,bool>> expression);
        List<T> ToList();
        T FindById(int id);
        T FirstOrDefault(Expression<Func<T, bool>> expression);
        T LastOrDefault(Expression<Func<T, bool>> expression);
        IQueryable<T> Include(params Expression<Func<T, object>>[] includes);
        IQueryable<TType> Select<TType>(Expression<Func<T, TType>> select);
        bool Any(Expression<Func<T, bool>> expression = null);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression = null);
        IQueryable<T> Tracking(bool Tracking);
        double Sum(Expression<Func<T, double>> expression);
        IQueryable<T> Take(int count);
        IQueryable<T> Skip(int count);
        int Count(Expression<Func<T, bool>> expression = null);
        int Max(Expression<Func<T, int>> expression);
        IQueryable<T> OrderBy(Expression<Func<T, int>> expression);
        Task<List<T>> ToListAsync();
        Task<T> FindByIdAsync(int id);
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(ICollection<T> entity);
        Task<ResponseResult> DeleteAsync(int id);
        bool DeleteRange(List<T> entity);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression = null);
        Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> expression = null);
        IQueryable<T> OrderByDescending(Expression<Func<T, object>> expression);
        Task<int> MaxAsync(Expression<Func<T, int>> expression);
        Task<int> CountAsync();
       // Task<Paging<List<T>, List<R>>> GetAll<R>(int pageNumber, int pageSize, Expression<Func<T, bool>> criteria, Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy);
    }
}
