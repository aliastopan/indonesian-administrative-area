using IndonesianAdministrativeArea.Models.Dtos;
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

        List<ProvinceDto> provinceDtoList = await AdministrativeAreaService.GetIndonesianProvinces();

        Console.WriteLine("Complete.\n");

        JsonService.Serializer.SerializeToJson<ProvinceDto>(provinceDtoList, "provinces.json");
    }
}
