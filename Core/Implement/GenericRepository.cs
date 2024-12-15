using Application.Interfaces;
using Domain.Dto;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query;
using DataAccess;
using AutoMapper;

namespace Application.Implement
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        protected ApplicationDBContext _context;
        private readonly DbSet<T> Table;
        private readonly string UserName = "";
        private readonly string UserId = "";
        private readonly string IpAddress = "";
        /// <summary>
        /// private IMapper _mapper;
        /// </summary>
        private readonly IHttpContextAccessor _iHttpContextAccessor;

        public GenericRepository(ApplicationDBContext context/*, IMapper mapper*/)
        {
            _context = context;
           /// _mapper = mapper;
            Table = _context.Set<T>();
        }
        /////////////////////////////
        public T FindById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public bool Add(T entity)
        {
            if (entity == null)
            {
                throw new NullReferenceException();
            }
            entity.CreatedDate = DateTime.Now;
            Table.Add(entity);
            return true;
        }
        public bool AddRange(IEnumerable<T> entity)
        {
            if (entity.Count() == 0)
            {
                throw new NullReferenceException();
            }
            foreach (var item in entity)
            {
                item.CreatedDate = DateTime.Now;
            }
            Table.AddRange(entity);
            return true;
        }
        public async Task<ResponseResult> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new NullReferenceException();
            }
            var model = await FindByIdAsync(entity.Id);
            if (model == null)
            {
             return new ResponseResult { IsSuccess = false, Message = "NotFound" };
            }
            Table.Update(entity);
            return new ResponseResult { IsSuccess = true, Message = "Update Success", Obj = model };
        }
        public bool Remove(T entity)
        {
            if (entity == null)
            {
                throw new NullReferenceException();
            }

                Table.Remove(entity);
            
            return true;
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return Table.Where(expression);
        }
        public List<T> ToList()
        {
            return Table.ToList();
        }
        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            if (expression != null)
                return Table.FirstOrDefault(expression);
            else
                return Table.FirstOrDefault();
        }
        public T LastOrDefault(Expression<Func<T, bool>> expression)
        {
            if (expression != null)
                return Table.OrderBy(x => x.Id).LastOrDefault(expression);
            else
                return Table.OrderBy(x => x.Id).LastOrDefault();
        }
        public IQueryable<T> Include(params Expression<Func<T, object>>[] includes)
        {
            IIncludableQueryable<T, object> query = null;
            foreach (var include in includes)
                query = Table.Include(include);
            return query;
        }
        public IQueryable<TType> Select<TType>(Expression<Func<T, TType>> select)
        {
            return Table.Select(select);
        }
        public bool Any(Expression<Func<T, bool>> expression = null)
        {
            if (expression != null)
                return Table.Any(expression);
            else
                return Table.Any();
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression = null)
        {
            if (expression != null)
                return await Table.AnyAsync(expression);
            else
                return await Table.AnyAsync();
        }
        public IQueryable<T> Tracking(bool Tracking = false)
        {
            if (Tracking)
            {
                return Table.AsTracking();
            }
            else
            {
                return Table.AsNoTracking();
            } 
        }
        public double Sum(Expression<Func<T, double>> expression)
        {
            return Table.Sum(expression);
        }
        public IQueryable<T> Take(int count)
        {
            return Table.Take(count);
        }
        public IQueryable<T> Skip(int count)
        {
            return Table.Skip(count);

        }
        public int Count(Expression<Func<T, bool>> expression = null)
        {
            return Table.Count(expression);
        }
        public int Max(Expression<Func<T, int>> expression)
        {
            try
            {
                return Table.Max(expression);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public IQueryable<T> OrderBy(Expression<Func<T, int>> expression)
        {
            return Table.OrderBy(expression);
        }
        public async Task<List<T>> ToListAsync()
        {
            var list = await Table.ToListAsync();
            return list;
        }
        public async Task<T> FindByIdAsync(int id)
        {
            var model = await Table.FindAsync(id);
            return model;
        }
        public async Task<bool> AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new NullReferenceException();
            }

            entity.CreatedDate = DateTime.Now;
            await Table.AddAsync(entity);
            return true;
        }
        public async Task<bool> AddRangeAsync(ICollection<T> entity)
        {
            if (entity.Count() == 0)
            {
                throw new NullReferenceException();
            }
            foreach (var item in entity)
            {
                item.CreatedDate = DateTime.Now;
            }
            await Table.AddRangeAsync(entity);
            return true;
        }
        public async Task<ResponseResult> DeleteAsync(int id)
        {
            var model = await FindByIdAsync(id);

            if (model == null)
            {
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };
            }
            Remove(model);
            return new ResponseResult { IsSuccess = true, Message = "Delete Success" };
        }
        public bool DeleteRange(List<T> entity)
        {
            try
            {           
                Table.RemoveRange(entity);           
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression = null)
        {
            if (expression == null)
                return await Table.FirstOrDefaultAsync();
            else
                return await Table.FirstOrDefaultAsync(expression);
        }
        public async Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> expression = null)
        {
            if (expression == null)
                return await Table.LastOrDefaultAsync();
            else
                return await Table.LastOrDefaultAsync(expression);
        }
        public IQueryable<T> OrderByDescending(Expression<Func<T, object>> expression)
        {
            return Table.OrderByDescending(expression);
        }
        public async Task<int> MaxAsync(Expression<Func<T, int>> expression)
        {
            var result = 0;
            try
            {
                result = await Table.MaxAsync(expression);
            }
            catch (Exception)
            {
            }
            return result;
        }
        public async Task<int> CountAsync()
        {
            return Table.Count();
        }
        //
       //public async Task<Paging<List<T>, List<R>>> GetAll<R>(int pageNumber, int pageSize, Expression<Func<T, bool>> criteria, Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy)
       // {
       //     IQueryable<T> query = _context.Set<T>();
       //     query = query.Where(criteria);
       //     query = OrderBy(query);
       //     int recCount = query.Count();
       //     int totalPages = (int)Math.Ceiling((decimal)recCount / (decimal)pageSize);
       //     var skip = (pageNumber - 1) * pageSize;
       //     var data = await query.Skip(skip).Take(pageSize).ToListAsync();

       //     var finaldata = _mapper.Map<List<R>>(data);

       //     return new Paging<List<T>, List<R>>(finaldata, totalPages, pageNumber, pageSize, recCount);
       // }
    }
}
