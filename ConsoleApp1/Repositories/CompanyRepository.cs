
using ConsoleApp1.Contexts;
using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace ConsoleApp1.Repositories;

internal class CompanyRepository : Repo<CompanyEntity>
{
    private readonly DataContext _context;

    public CompanyRepository(DataContext context) : base(context)
    { 
        _context = context;
    }

    public override CompanyEntity Get(Expression<Func<CompanyEntity, bool>> expression)
    {
        var entity = _context.Companies
            .Include(i => i.Address)
            .Include(i => i.ContactPerson)
            .Include(i => i.Note)
            .FirstOrDefault(expression);
        return entity!;
    }

    public override IEnumerable<CompanyEntity> GetAll()
    {
        return _context.Companies
            .Include(i => i.Address)
            .Include(i => i.ContactPerson)
            .Include(i => i.Note)
            .ToList();
    }
}
