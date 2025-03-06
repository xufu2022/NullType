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