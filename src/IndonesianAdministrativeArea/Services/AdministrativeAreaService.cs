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
}
