#nullable enable

public class Person
{
    public required string FirstName { get; set; }
    public string MiddleName { get; set; } = string.Empty;
    public required string LastName { get; set; }
	public StreetAddress? Address { get; set; }
    public int Age { get; set; }
}

public record StreetAddress(string Street, string ZipCode, string StateCode);