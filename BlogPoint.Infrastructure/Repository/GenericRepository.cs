
using BlogPoint.Core.Interfaces;
using BlogPoint.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogPoint.Infrastructure.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private DbSet<T> table = null;
    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        table = _context.Set<T>();
    }


    public IEnumerable<T> GetAll()
    {
        return table.ToList();

    }

    public T GetById(int id)
    {
        return table.Find(id);
    }


    public void Create(T entity)
    {
        table.Add(entity);
    }

    public void Delete(int id)
    {
        T entity = GetById(id);
        table.Remove(entity);
    }

    public void Update(T entity)
    {
        table.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }
}