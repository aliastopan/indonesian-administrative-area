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

        return JsonService.Deserializer.DeserializeProvinces(response);
    }
}
