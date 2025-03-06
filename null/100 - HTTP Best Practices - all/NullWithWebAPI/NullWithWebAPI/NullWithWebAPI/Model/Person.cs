using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NullWithWebAPI.Server.Model;

public abstract class Person
{
    public int ID { get; set; }

    [Required]
    [StringLength(50)]
    public required string LastName { get; set; }
    [Required]
    [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
    [Column("FirstName")]
    public required string FirstMidName { get; set; }

    public string FullName
    {
        get
        {
            return LastName + ", " + FirstMidName;
        }
    }
}