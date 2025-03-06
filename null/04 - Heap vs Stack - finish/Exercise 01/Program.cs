// Value types

// A list of value types in C#:
// 1. bool
// 2. byte
// 3. sbyte
// 4. char
// 5. decimal
// 6. double
// 7. float
// 8. int
// 9. uint
// 10. long
// 11. ulong
// 12. short
// 13. ushort
// 14. enum
// 15. struct

bool sampleBool = default;
Console.WriteLine($"bool defaults to {sampleBool}");

int sampleInt = default;
Console.WriteLine($"int defaults to {sampleInt}");

double sampleDouble = default;
Console.WriteLine($"double defaults to {sampleDouble}");

DayOfWeek sampleEnum = default;
Console.WriteLine($"DayOfWeek enum defaults to {sampleEnum}");

char sampleChar = default;
Console.WriteLine($"char defaults to \\u{(int)sampleChar:X}");

// Reference types

string sampleString = default;
Console.WriteLine($"string defaults to null, {sampleString == null}");

var person = new Person { Name = "Alice", Age = 30 };
var person2 = person;

Console.WriteLine($"person: {person.Name} is {person.Age}");
Console.WriteLine($"person2: {person2.Name} is {person2.Age}");

person.Name = "Bob";

Console.WriteLine($"person: {person.Name} is {person.Age}");
Console.WriteLine($"person2: {person2.Name} is {person2.Age}");

// | var           | Stack      | Heap                                         |
// |---------------|------------|----------------------------------------------|
// | sampleBool    | false      |                                              |    
// | sampleInt     | 0          |                                              |
// | sampleDouble  | 0          |                                              |
// | sampleEnum    | Sunday     |                                              |
// | sampleChar    | \u0000     |                                              |
// | sampleString  | null       |                                              |
// | person        | 0x0001     | (0x0001) Person { Name = "Bob", Age = 30 }   |
// | person2       | 0x0001     |                                              |

public class Person
{
	public string Name { get; set; }
	public int Age { get; set; }
}