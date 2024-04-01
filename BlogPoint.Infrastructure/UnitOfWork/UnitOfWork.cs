

using BlogPoint.Core.Interfaces;
using BlogPoint.Infrastructure.Data;
using BlogPoint.Infrastructure.Repository;

namespace BlogPoint.Infrastructure.UnitOfWork;

public class UnitOfWork<T> : IUnitOfWork<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private IGenericRepository<T> _entity;
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IGenericRepository<T> Entity
    {
        get
        {
            return _entity ?? (_entity = new GenericRepository<T>(_context));
        }
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}