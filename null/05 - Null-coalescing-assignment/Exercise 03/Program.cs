// nullable context is enabled

VehicleService vehicleServiceInstance = new VehicleService();

Vehicle vehicle = vehicleServiceInstance.GetVehicleByIdOrDefault(2);

string color = vehicle.Color;

Console.WriteLine($"Color: {color}");