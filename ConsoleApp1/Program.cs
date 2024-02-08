using ConsoleApp1.Contexts;
using ConsoleApp1.Repositories;
using ConsoleApp1.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{ 
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\ec\ConsoleApp1\ConsoleApp1\Data\local_db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));
    
    services.AddScoped<AddressRepository>();
    services.AddScoped<CompanyRepository>();
    services.AddScoped<ContactPersonRepository>();
    services.AddScoped<NoteRepository>();
    services.AddScoped<RoleRepository>();

    services.AddScoped<AddressService>();
    services.AddScoped<CompanyService>();
    services.AddScoped<ContactPersonService>();
    services.AddScoped<NoteService>();
    services.AddScoped<RoleService>();


}).Build();