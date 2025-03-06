using NullWithWebAPI.Shared.DTO;

namespace NullWithWebAPI.Server.Model;


public static class Map
{
    public static List<Shared.DTO.Student> ToDTO(this List<Student> students) => students.Select(s=> s.ToDTO()).ToList();
    public static Shared.DTO.Student ToDTO(this Student s) =>
        new Shared.DTO.Student(s.ID, s.LastName, s.FirstMidName, s.EnrollmentDate, s.Enrollments.ToDto());

    public static Shared.DTO.Enrollment ToDTO(this Enrollment e) =>
        new Shared.DTO.Enrollment(e.EnrollmentID, e.Course.ToDTO(), e.Grade);

    private static ICollection<Shared.DTO.Enrollment> ToDto(this ICollection<Enrollment> e)
        => e.Select(item => item.ToDTO()).ToArray();

    public static Shared.DTO.Course ToDTO(this Course c) =>
        new Shared.DTO.Course(c.CourseID, c.Title, c.Credits, c.DepartmentID);
}
