
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Entities;

internal class RoleEntity
{
    [Key]
    public int Id { get; set; }
    public string Role { get; set; } = null!;
}
