// nullable context is enabled

VehicleService vehicleServiceInstance = new VehicleService();

Vehicle vehicle = vehicleServiceInstance.GetVehicleById(1);

string color = vehicle.Color;

Console.WriteLine($"Color: {color}");