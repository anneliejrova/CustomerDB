
using System.ComponentModel.DataAnnotations;


namespace ConsoleApp1.Entities;

internal class ContactPersonEntity
{
    [Key]
    public int Id { get; set; }

    public int RoleId { get; set; }
    public RoleEntity Role { get; set; } = null!;

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PersonalEmail { get; set; } = null!;
    public string DirectPhone { get; set; } = null!;

}
