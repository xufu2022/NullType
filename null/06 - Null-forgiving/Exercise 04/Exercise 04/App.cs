public class App(VehicleService VehicleService)
{
	public Task Run()
	{
		Vehicle Vehicle = VehicleService.GetVehicleByIdOrDefault(1);
		Console.WriteLine(Vehicle);
		return Task.CompletedTask;
	}
}