public record Vehicle(int Id, string Make, string Model, string Color);
public class VehicleService
{
	Vehicle defaultVehicle = new(-1, "Not Found", "Not Found", "No Color");
	/// <summary>
	/// Gets a Vehicle by id, if a Vehicle is not found a null is returned.
	/// </summary>
	/// <param name="id"></param>
	/// <remarks>
	/// For example purposes null is always returned if the id is 1.
	/// All other id's will echo the id value.
	/// </remarks>
	/// <returns>
	/// 1: null<br/>
	/// 2: {2, "Sportster", "Dotnet-2", "Purple-2"}<br/>
	/// 3: {3, "Sportster", "Dotnet-3", "Purple-3"}<br/>
	/// </returns>
	public Vehicle? GetVehicleById(int id) =>
		id == 1 ? null // allways return null for id = 1
		: new(id, "Sportster", $"Dotnet-{id}", $"Purple-{id}"); // echo the id

	public Vehicle GetVehicleByIdOrDefault(int id) => GetVehicleById(id) ?? defaultVehicle;
}