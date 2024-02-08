
using ConsoleApp1.Contexts;
using ConsoleApp1.Entities;

namespace ConsoleApp1.Repositories;

internal class RoleRepository : Repo<RoleEntity>
{
    public RoleRepository(DataContext context) : base(context)
    {

    }
}
