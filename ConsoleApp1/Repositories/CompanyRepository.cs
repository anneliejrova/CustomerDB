
using ConsoleApp1.Contexts;
using ConsoleApp1.Entities;

namespace ConsoleApp1.Repositories;

internal class CompanyRepository : Repo<CompanyEntity>
{
    public CompanyRepository(DataContext context) : base(context)
    {
    }
}
