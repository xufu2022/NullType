using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NullWithWebAPI.Server.Model;

public class CourseAssignment
{
    public required int InstructorID { get; set; }
    public required int CourseID { get; set; }
    public Instructor Instructor { get; set; } = null!;
    public Course Course { get; set; } = null!;  
}