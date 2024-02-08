
using ConsoleApp1.Contexts;
using System.Linq.Expressions;

namespace ConsoleApp1.Repositories;


internal class Repo<TEntity> where TEntity : class
{
    private readonly DataContext _context;

    public Repo(DataContext context)
    {
        _context = context;
    }


    public TEntity Create(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public TEntity Get(Expression<Func<TEntity, bool>> expression)
    {
        var entity = _context.Set<TEntity>().FirstOrDefault(expression);
        return entity!;
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
       
    }

    public TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
    {
        var toUpdate = _context.Set<TEntity>().FirstOrDefault();
        _context.Entry(toUpdate!).CurrentValues.SetValues(entity);
        _context.SaveChanges();

        return toUpdate!;
    }

    public void Delete(Expression<Func<TEntity, bool>> expression)
    {
        var entity = _context.Set<TEntity>().FirstOrDefault(expression);
        _context.Remove(entity!);
        _context.SaveChanges();
    }
}
 