#nullable enable
Vehicle? vehicle = default;

string? color = vehicle?.Color;

Console.WriteLine($"Color: {color}");

int index = 0;
Vehicle[]? reservations = default;
reservations = [];

Vehicle? reservation = reservations?.ElementAtOrDefault(index);

Console.WriteLine($"Reservation: {reservation?.Color} {reservation?.Make} {reservation?.Model}");

public record Vehicle(int Id, string Make, string Model, string Color);