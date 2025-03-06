using NullWithWebAPI.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NullWithWebAPI.Server.Model;

public class Enrollment
{
    public int EnrollmentID { get; set; }
    public int CourseID { get; set; }
    public int StudentID { get; set; }
    // TODO: Null topic
    [DisplayFormat(NullDisplayText = "No grade")]
    public Grade? Grade { get; set; }
    public Course Course { get; set; } = null!;
    public Student? Student { get; set; }
}