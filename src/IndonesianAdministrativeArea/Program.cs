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

        List<ProvinceDto> provinceDtos = await AdministrativeAreaService.GetIndonesianProvinces();
        List<RegencyDto> regencyDtos = await AdministrativeAreaService.GetIndonesianRegencies(provinceDtos);

        Console.WriteLine("Complete.\n");

        JsonService.Serializer.SerializeToJson<ProvinceDto>(provinceDtos, "provinces.json");
        JsonService.Serializer.SerializeToJson<RegencyDto>(regencyDtos, "regencies.json");

    }
}
