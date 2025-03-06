List<object?> data = ["Hello World", null, new { Message = "I'm an object"}];

foreach (var item in data)
{
	if (item is string)
	{
		Console.WriteLine(item);
	}
}