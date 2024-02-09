
using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Contexts;

internal class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<CompanyEntity> Companies { get; set; }
    public DbSet<ContactPersonEntity> ContactPersons { get; set; }
    public DbSet<NoteEntity> Notes { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
}

