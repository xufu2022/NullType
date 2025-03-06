﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NullWithWebAPI.Server.Model;

public class OfficeAssignment
{
    [Key]
    public required int InstructorID { get; set; }
    [StringLength(50)]
    [Display(Name = "Office Location")]
    public required string Location { get; set; }

    public Instructor Instructor { get; set; } = null!;
}