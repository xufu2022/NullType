public class Person
{
	public string FirstName { get; set; }
	public string? MiddleName { get; set; }
	public string LastName { get; set; }
	public int? Age { get; set; }
	public Address? Address { get; set; }

	public Person(string firstName, string lastName, string? middleName = null)
	{
		FirstName = firstName;
		LastName = lastName;
		MiddleName = middleName;
	}
	public static Person?[] GetPeople() => [
		new("John", "Doe"),
		new("Jane", "Doe"),
		null,
		new("Robert", "Tables", "Oscar") { Age = 39 },
		new("Roberta", "Tables", "Olive") { Address= new("123 Street", "50064", "KY"), Age = 35 }
	];

}

public record Address(string Street, string ZipCode, string StateCode);