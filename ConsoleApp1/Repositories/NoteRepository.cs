
using ConsoleApp1.Contexts;
using ConsoleApp1.Entities;

namespace ConsoleApp1.Repositories;

internal class NoteRepository : Repo<NoteEntity>
{
    public NoteRepository(DataContext context) : base(context)
    {

    }
}
