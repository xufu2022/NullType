VehicleService vehicleService = VehicleService.Create();

TimeSpan timeSinceCreated = DateTime.UtcNow - VehicleService.CreatedOn.Value;

Customer newCustomer = new(1, "John Doe", "jdoe@dometrain.com");

Reservation reservation = new()
{
	Customer = newCustomer,
};

Vehicle availableRental = vehicleService.GetVehicleByIdOrDefault(2);

reservation.Vehicle = availableRental;

reservation.Cancel();