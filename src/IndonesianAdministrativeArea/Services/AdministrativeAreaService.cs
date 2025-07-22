using IndonesianAdministrativeArea.Models.Contracts;
using IndonesianAdministrativeArea.Models.Dtos;

namespace IndonesianAdministrativeArea.Services;

public static class AdministrativeAreaService
{
    public static async Task<List<ProvinceDto>> GetIndonesianProvinces()
    {
        string url = "https://wilayah.id/api/provinces.json";
        WilayahIdResponse? response = await HttpClientService.GetAdministrativeArea(url)
            ?? throw new NullReferenceException();

        Console.WriteLine($"Provinces: 100% (1/1)");

        return JsonService.Deserializer.DeserializeProvinceDtos(response);
    }

    public static async Task<List<RegencyDto>> GetIndonesianRegencies(List<ProvinceDto> provinceDtos)
    {
        int numberOfProvince = provinceDtos.Count;
        int progress = 0;

        List<RegencyDto> indonesianRegencies = [];

        foreach (var province in provinceDtos)
        {
            string url = $"https://wilayah.id/api/regencies/{province.Code}.json";
            WilayahIdResponse? response = await HttpClientService.GetAdministrativeArea(url)
                ?? throw new NullReferenceException();

            List<RegencyDto> dtos = JsonService.Deserializer.DeserializeRegencieDtos(response);
            indonesianRegencies.AddRange(dtos);

            progress++;
            double percent = (double)progress / numberOfProvince * 100;
            Console.Write($"\rRegencies: {percent:F0}% ({progress}/{numberOfProvince})");
        }

        Console.Write("\n");

        return indonesianRegencies;
    }

    public static async Task<List<DistrictDto>> GetIndonesianDistrict(List<RegencyDto> regencyDtos)
    {
        int numberOfRegencies = regencyDtos.Count;
        int progress = 0;

        List<DistrictDto> indonesianDistricts = [];

        foreach (var regency in regencyDtos)
        {
            string url = $"https://wilayah.id/api/districts/{regency.Code}.json";
            WilayahIdResponse? response = await HttpClientService.GetAdministrativeArea(url)
                ?? throw new NullReferenceException();

            List<DistrictDto> dtos = JsonService.Deserializer.DeserializeDistrictDtos(response);
            indonesianDistricts.AddRange(dtos);

            progress++;
            double percent = (double)progress / numberOfRegencies * 100;
            Console.Write($"\rDistricts: {percent:F0}% ({progress}/{numberOfRegencies})");
        }

        Console.Write("\n");

        return indonesianDistricts;
    }

    public static async Task<List<VillageDto>> GetIndonesianVillages(List<DistrictDto> districtDtos)
    {
        int numberOfDistricts = districtDtos.Count;
        int progress = 0;

        List<VillageDto> indonesianVillage = [];

        foreach (var district in districtDtos)
        {
            string url = $"https://wilayah.id/api/villages/{district.Code}.json";
            WilayahIdResponse? response = await HttpClientService.GetAdministrativeArea(url)
                ?? throw new NullReferenceException();

            List<VillageDto> dtos = JsonService.Deserializer.DeserializeVillageDtos(response);
            indonesianVillage.AddRange(dtos);

            progress++;
            double percent = (double)progress / numberOfDistricts * 100;
            Console.Write($"\rVillages: {percent:F0}% ({progress}/{numberOfDistricts})");
        }

        Console.Write("\n");

        return indonesianVillage;
    }

}
