
using ConsoleApp1.Contexts;
using ConsoleApp1.Entities;

namespace ConsoleApp1.Repositories;

internal class AddressRepository : Repo<AddressEntity>
{
    public AddressRepository(DataContext context) : base(context)
    {

    }
}
