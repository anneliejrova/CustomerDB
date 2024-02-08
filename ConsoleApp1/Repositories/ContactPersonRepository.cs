
using ConsoleApp1.Contexts;
using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ConsoleApp1.Repositories;

internal class ContactPersonRepository : Repo<ContactPersonEntity>
{
    private readonly DataContext _context;
    public ContactPersonRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override ContactPersonEntity Get(Expression<Func<ContactPersonEntity, bool>> expression)
    {
        var entity = _context.ContactPersons
           .Include(i => i.Role)
           .FirstOrDefault(expression);

        return entity!;
    }

    public override IEnumerable<ContactPersonEntity> GetAll()
    {
        return _context.ContactPersons
           .Include(i => i.Role)
           .ToList();
    }
}
