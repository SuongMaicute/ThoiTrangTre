using Microsoft.EntityFrameworkCore;
using API.Repositoty.IRepositoty;
using System.Linq.Expressions;
using API.DBContext;

namespace API.Repositoty
{
    public class Repository<T>: IRepository<T> where T : class
    {
        private readonly ThoiTrangContext _db;
        internal DbSet<T> Dbset;
        public Repository(ThoiTrangContext db)
        {
            _db = db;
            this.Dbset = _db.Set<T>();

        }

        public T GetNotracking(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = Dbset;
            query = query.Where(filter).AsNoTracking();
            return query.FirstOrDefault();
        } 
        public void Add(T entity)
        {
            Dbset.Add(entity);
        }
        public void AddSave(T entity)
        {
            Dbset.Add(entity);
            _db.SaveChanges();
        }

        public T? Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = Dbset;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = Dbset;
            query = query.Where(filter);
            return query.ToList();
        }
        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = Dbset;
            return query.ToList();
        }

        public void Remove(T entity)
        {
            Dbset.Remove(entity);
        }
        public void RemoveSave(T entity)
        {
            Dbset.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            Dbset.RemoveRange(entity);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(T entity)
        {
            Dbset.Update(entity);
        }
    }
}
