
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Entities;

internal class NoteEntity
{
    [Key]
    public int Id { get; set; }
    public string Note { get; set; } = null!;
}
