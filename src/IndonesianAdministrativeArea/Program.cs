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
        List<DistrictDto> districtDtos = await AdministrativeAreaService.GetIndonesianDistrict(regencyDtos);
        List<VillageDto> villageDtos = await AdministrativeAreaService.GetIndonesianVillages(districtDtos);

        Console.WriteLine("Complete.\n");

        JsonService.Serializer.SerializeToJson<ProvinceDto>(provinceDtos, "provinces.json");
        JsonService.Serializer.SerializeToJson<RegencyDto>(regencyDtos, "regencies.json");
        JsonService.Serializer.SerializeToJson<DistrictDto>(districtDtos, "districts.json");
        JsonService.Serializer.SerializeToJson<VillageDto>(villageDtos, "villages.json");
    }
}
