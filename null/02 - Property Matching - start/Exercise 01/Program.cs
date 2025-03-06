Person?[] people = Person.GetPeople();

foreach (Person? person in people)
{
	if(person is Person)
	{
	}
}