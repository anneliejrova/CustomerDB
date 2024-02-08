
using ConsoleApp1.Contexts;
using ConsoleApp1.Entities;

namespace ConsoleApp1.Repositories;

internal class ContactPersonRepository : Repo<ContactPersonEntity>
{
    public ContactPersonRepository(DataContext context) : base(context)
    {

    }
}
