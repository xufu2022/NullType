#nullable disable

public class Person
{
	public string FirstName { get; set; }
	public string MiddleName { get; set; }
	public string LastName { get; set; }
	public StreetAddress? Address { get; set; }
	public int Age { get; set; }
}

public record StreetAddress(string Street, string ZipCode, string StateCode);