Person?[] people = Person.GetPeople();

foreach (Person? person in people)
{
    var description = person switch
    {
        { FirstName: "John"} => "This person is named John",
        { Address: { } a } => $"This person has an address of {a.Street}",
        { } => "This person is not null",
        _ => "This person is null"
    };

    Console.WriteLine(description);
}