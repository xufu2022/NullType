namespace NullWithWebAPI.Shared.DTO;

public record Student(int ID, string LastName, string FirstName, DateTime EnrollmentDate, ICollection<Enrollment> Enrollments)
{
    public string FullName => LastName + ", " + FirstName;
}
