using IndonesianAdministrativeArea.Models.Regions;
using IndonesianAdministrativeArea.Services;

internal class Program
{
    private static async Task Main(string[] args)
    {
        await GetAdministrativeAreasOfIndonesia();
    }

    private static async Task GetAdministrativeAreasOfIndonesia()
    {
        Console.WriteLine("Requesting administrative area...");

        List<Province> provinces = await AdministrativeAreaService.GetIndonesianProvinces();

        Console.WriteLine("Complete.\n");

        JsonService.Serializer.SerializeToJson<Province>(provinces, "provinces.json");
    }
}
