
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Entities;

internal class CompanyEntity
{
    [Key]
    public int Id { get; set; } 
    public string CompanyName { get; set; } = null!;
    public string Website { get; set;} = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;

    public int AddressId { get; set; }
    public AddressEntity Address { get; set; } = null!;

    public int ContactPersonId {  get; set; }
    public ContactPersonEntity ContactPerson { get; set; } = null!;

    public int NoteId { get; set; }
    public NoteEntity Note { get; set; } = null!;


}
