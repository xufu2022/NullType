using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NullWithWebAPI.Server.Model;
public class Instructor : Person
{
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Hire Date")]
    public DateTime HireDate { get; set; }

    public ICollection<CourseAssignment> CourseAssignments { get; set; } = null!;
    public OfficeAssignment OfficeAssignment { get; set; } = null!;
}