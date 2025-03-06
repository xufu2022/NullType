//int count = null; // => Error

/* Csharp 2.0+ */

//Nullable<int> count = null; // => null
int? count2 = null; // => null

int? first = null;
Console.WriteLine($"First: {first}");

int? second = default;
Console.WriteLine($"Second: {second}");

int? third = new();
Console.WriteLine($"Third: {third}");

int? fourth = 1337;
Console.WriteLine($"Fourth: {fourth}");