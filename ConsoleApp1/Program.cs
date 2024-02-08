using ConsoleApp1.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\ec\ConsoleApp1\ConsoleApp1\Data\local_db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));

}).Build();