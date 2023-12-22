
using Microsoft.EntityFrameworkCore;
using RestfulWebApi.DataLayer;

namespace RestfulWebApiEx.Repository
{
    public class EFRepository<T> : IGenericRepository<T> where T : class, new()

    {
        private readonly DataBaseContext _context;
        private readonly DbSet<T> _dbSet;

        public EFRepository(DataBaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        //DB erişimi yappıldı.

        public T Add(T entity)
        {
            var result = new T();
            _dbSet.Add(entity);//Gönderilen entiy i contexte set etti.
            _context.SaveChanges();//Db değişiklikleri kaydet.
            result = entity;
            return result;
        }

        public T Delete(T entity)
        {
            var result = new T();
            _dbSet.Remove(entity);
            _context.SaveChanges();
            result = entity;
            return result;
        }

        public List<T> GetAll()
        {
            var result = new List<T>();
            var list = _dbSet.ToList();
            if (list != null)
                result = list;
            else
                result = null;
                return result;
        }

        public T GetById(int id)
        {
             var result = new T();
             result = _dbSet.Find(id);
             return result;
        }

        public T UpdateById(T entity, int id)
        {
            var result = new T();
            var model = _dbSet.Find(id);
            if(model==null)
                return null;
            else
            {
                _context.Entry(model).CurrentValues.SetValues(entity);
                _context.SaveChanges();
                result = model;
                return result;
            }

            
        }
    }
}