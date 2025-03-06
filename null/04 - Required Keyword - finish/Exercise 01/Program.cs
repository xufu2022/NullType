#nullable enable
Person p = new()  { FirstName = "John", LastName = "Doe" };
//p.FirstName = "John";
//p.LastName = "Doe";

string street = p.Address?.Street ?? "";

Console.WriteLine($"Street Address: {street}");