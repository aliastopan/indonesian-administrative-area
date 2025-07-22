using System.Diagnostics;
using IndonesianAdministrativeArea.Models.Dtos;
using IndonesianAdministrativeArea.Services;

internal class Program
{
    private static async Task Main(string[] args)
    {
        // await GetAdministrativeAreasOfIndonesia();
        await Task.CompletedTask;
    }

    private static async Task GetAdministrativeAreasOfIndonesia()
    {
        Stopwatch stopwatch = new Stopwatch();

        Console.WriteLine("Requesting administrative area...");

        stopwatch.Start();

        List<ProvinceDto> provinceDtos = await AdministrativeAreaService.GetIndonesianProvinces();
        List<RegencyDto> regencyDtos = await AdministrativeAreaService.GetIndonesianRegencies(provinceDtos);
        List<DistrictDto> districtDtos = await AdministrativeAreaService.GetIndonesianDistrict(regencyDtos);
        List<VillageDto> villageDtos = await AdministrativeAreaService.GetIndonesianVillages(districtDtos);

        Console.WriteLine("Stand by.\n");
        Console.WriteLine("Serializing administrative area...");

        JsonService.Serializer.SerializeToJson<ProvinceDto>(provinceDtos, "provinces.json");
        JsonService.Serializer.SerializeToJson<RegencyDto>(regencyDtos, "regencies.json");
        JsonService.Serializer.SerializeToJson<DistrictDto>(districtDtos, "districts.json");
        JsonService.Serializer.SerializeToJson<VillageDto>(villageDtos, "villages.json");

        stopwatch.Stop();

        Console.WriteLine($"Completed in {stopwatch.Elapsed.Minutes:D2} minutes and {stopwatch.Elapsed.Seconds:D2} seconds.\n");
    }
}
