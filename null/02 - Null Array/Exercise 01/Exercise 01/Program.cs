#nullable enable
Vehicle? vehicle = default;

string? color = vehicle?.Color;

Console.WriteLine($"Color: {color}");

public record Vehicle(int Id, string Make, string Model, string Color);