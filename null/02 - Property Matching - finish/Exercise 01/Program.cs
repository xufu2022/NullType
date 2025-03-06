Person?[] people = Person.GetPeople();

foreach (Person? person in people)
{
	if (person is Person { FirstName: { } f } and { MiddleName: { } m } and { LastName: { } l })
	{
		Console.WriteLine($"First Name: {f}, Middle Name: {m}, LastName: {l}");
	}

	if (person is Person { FirstName: { } f2 } and { MiddleName: null } and { LastName: { } l2 })
	{
		Console.WriteLine($"First Name: {f2}, LastName: {l2}");
	}

	if (person is Person { Address: { } a })
	{
		Console.WriteLine(a.ToString());
	}
}