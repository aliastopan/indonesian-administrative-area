using System.Text.Json;
using IndonesianAdministrativeArea.Extensions;
using IndonesianAdministrativeArea.Models.Contracts;
using IndonesianAdministrativeArea.Models.Dtos;

namespace IndonesianAdministrativeArea.Services;

public static class JsonService
{
    public static class Deserializer
    {
        public static List<ProvinceDto> DeserializeProvinceDtos(WilayahIdResponse wilayahIdResponse)
        {
            return wilayahIdResponse.Data
                .Select(province => new ProvinceDto(province.Code, province.Name))
                .OrderByProvinceCode();
        }

        public static List<RegencyDto> DeserializeRegencieDtos(WilayahIdResponse wilayahIdResponse)
        {
            return wilayahIdResponse.Data
                .Select(regency => new RegencyDto(regency.Code, regency.Code.GetProvinceCode(), regency.Name))
                .OrderByRegencyCode();
        }

        public static List<DistrictDto> DeserializeDistrictDtos(WilayahIdResponse wilayahIdResponse)
        {
            return wilayahIdResponse.Data
                .Select(district => new DistrictDto(district.Code, district.Code.GetRegencyCode(), district.Name))
                .OrderByDistrictCode();
        }

        public static List<VillageDto> DeserializeVillageDtos(WilayahIdResponse wilayahIdResponse)
        {
            return wilayahIdResponse.Data
                .Select(village => new VillageDto(village.Code, village.Code.GetDistrictCode(), village.Name))
                .OrderByVillageCode();
        }

        public static List<T> DeserializeDto<T>(string fileName)
        {
            string? jsonContent = ReadJson(fileName);

            if (jsonContent is null)
                return [];

            return JsonSerializer.Deserialize<List<T>>(jsonContent) ?? [];
        }

        private static string? ReadJson(string fileName)
        {
            string projectDir = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(projectDir, "..", "..", "data", "json", fileName);
            string fullPath = Path.GetFullPath(filePath);

            return File.ReadAllText(fullPath);
        }
    }

    public static class Serializer
    {
        public static void SerializeToJson<T>(List<T>? administrativeArea, string fileName)
        {
            string json = JsonSerializer.Serialize(administrativeArea, GetOptions());

            WriteJson(fileName, json);
        }

        private static void WriteJson(string fileName, string jsonBody)
        {
            string projectDir = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(projectDir, "..", "..", "data", "json", fileName);
            string fullPath = Path.GetFullPath(filePath);

            Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);

            File.WriteAllText(fullPath, jsonBody);
        }

        private static JsonSerializerOptions GetOptions()
        {
            return new JsonSerializerOptions
            {
                WriteIndented = true
            };
        }
    }
}
