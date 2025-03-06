using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NullWithWebAPI.Server.Model;
public class Course
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Display(Name = "Number")]
    public int CourseID { get; set; }

    [StringLength(50, MinimumLength = 3)]
    public required string Title { get; set; }

    [Range(0, 5)]
    public int Credits { get; set; }

    public int DepartmentID { get; set; }

    /* Are we using Include with our queries? If not, these should be nullable */
    public Department? Department { get; set; }
    public ICollection<Enrollment>? Enrollments { get; set; }
    public ICollection<CourseAssignment>? CourseAssignments { get; set; }
}