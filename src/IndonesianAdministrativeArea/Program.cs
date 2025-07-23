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

    private static void GenerateMeilisearchIndex()
    {
        Stopwatch stopwatch = new Stopwatch();

        Console.WriteLine("Generating Meilisearch index...");

        stopwatch.Start();

        List<ProvinceProper> provinces = JsonService.Deserializer.DeserializeIndex<ProvinceProper>("province.index.json");
        List<RegencyProper> regencies = JsonService.Deserializer.DeserializeIndex<RegencyProper>("regencies.index.json");
        List<DistrictProper> districts = JsonService.Deserializer.DeserializeIndex<DistrictProper>("district.index.json");
        List<VillageProper> villages = JsonService.Deserializer.DeserializeIndex<VillageProper>("villages.index.json");

        IndexService.SerializeMeilisearchIndexJson(provinces, regencies, districts, villages);

        stopwatch.Stop();

        Console.WriteLine($"\nCompleted in {stopwatch.Elapsed.TotalSeconds:F2} seconds.\n");
    }

    private static void GenerateUnitOfAreaIndex()
    {
        Stopwatch stopwatch = new Stopwatch();

        Console.WriteLine("Generating index...");

        stopwatch.Start();

        List<ProvinceDto> provinceDtos = JsonService.Deserializer.DeserializeDto<ProvinceDto>("provinces.json");
        List<ProvinceProper> provinces = provinceDtos.MapProvinceDtosToPropers();

        List<RegencyDto> regencyDtos = JsonService.Deserializer.DeserializeDto<RegencyDto>("regencies.json");
        List<RegencyProper> regencies = regencyDtos.MapRegencyDtosToPropers(provinceDtos);

        List<DistrictDto> districtDtos = JsonService.Deserializer.DeserializeDto<DistrictDto>("districts.json");
        List<DistrictProper> districts = districtDtos.MapDistrictDtosToPropers(regencyDtos, provinceDtos);

        // List<VillageDto> villageDtos = JsonService.Deserializer.DeserializeDto<VillageDto>("villages.json");
        // List<VillageProper> villages = villageDtos.MapVillageDtosToPropers(districtDtos, regencyDtos, provinceDtos);

        IndexService.SerializeIndexJson<ProvinceProper>(provinces, "province.index.json");
        IndexService.SerializeIndexJson<RegencyProper>(regencies, "regencies.index.json");
        IndexService.SerializeIndexJson<DistrictProper>(districts, "district.index.json");
        // IndexService.SerializeIndexJson<VillageProper>(villages, "villages.index.json");

        stopwatch.Stop();

        Console.WriteLine($"\nCompleted in {stopwatch.Elapsed.TotalSeconds:F2} seconds.\n");
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

        Console.WriteLine($"\nCompleted in {(int)stopwatch.Elapsed.TotalMinutes} minutes and {stopwatch.Elapsed.Seconds:D2} seconds.\n");
    }
}
