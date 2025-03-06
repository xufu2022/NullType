#nullable enable

public class Person
{
	public string FirstName { get; set; } = string.Empty;
	public string MiddleName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
	public StreetAddress? Address { get; set; }
	public int Age { get; set; }
}

public record StreetAddress(string Street, string ZipCode, string StateCode);