using EmployeeBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBackend.Repositories
{
    public class Repository<T>:IRepository<T> where T : class
    {
        private readonly EmployeeContext _context;
        private readonly DbSet<T> _table;

        public Repository(EmployeeContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public int Add(T entity)
        {
            _table.Add(entity);
            return _context.SaveChanges();
        }

        public int Delete(T entity)
        {
            _table.Remove(entity);
            return _context.SaveChanges();
        }

        public T Get(int id)
        {
            return _table.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        public T Update(T entity)
        {
            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
    }
}
