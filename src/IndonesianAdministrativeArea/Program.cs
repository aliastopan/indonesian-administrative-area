using System.Diagnostics;
using IndonesianAdministrativeArea.Extensions;
using IndonesianAdministrativeArea.Models.Dtos;
using IndonesianAdministrativeArea.Models.UnitOfArea;
using IndonesianAdministrativeArea.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        GenerateUnitOfAreaIndex();
    }

    private static void GenerateUnitOfAreaIndex()
    {
        Console.WriteLine("Generating index...");

        List<ProvinceDto> provinceDtos = JsonService.Deserializer.DeserializeDto<ProvinceDto>("provinces.json");
        List<ProvinceProper> provinces = provinceDtos.MapProvinceDtosToPropers();

        Console.WriteLine($"Total Provinsi: {provinces.Count}");

        List<RegencyDto> regencyDtos = JsonService.Deserializer.DeserializeDto<RegencyDto>("regencies.json");
        List<RegencyProper> regencies = regencyDtos.MapRegencyDtosToPropers(provinceDtos);

        Console.WriteLine($"Total Kabupaten/Kota: {regencies.Count}");

        List<DistrictDto> districtDtos = JsonService.Deserializer.DeserializeDto<DistrictDto>("districts.json");
        List<DistrictProper> districts = districtDtos.MapDistrictDtosToPropers(regencyDtos, provinceDtos);

        Console.WriteLine($"Total Kecamatan: {districts.Count}");

        IndexService.SerializeIndexJson<ProvinceProper>(provinces, "province.index.json");
        IndexService.SerializeIndexJson<RegencyProper>(regencies, "regencies.index.json");
        IndexService.SerializeIndexJson<DistrictProper>(districts, "district.index.json");

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
