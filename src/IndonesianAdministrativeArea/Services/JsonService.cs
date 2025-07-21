using System.Text.Json;
using IndonesianAdministrativeArea.Extensions;
using IndonesianAdministrativeArea.Models.Contracts;
using IndonesianAdministrativeArea.Models.Regions;

namespace IndonesianAdministrativeArea.Services;

public static class JsonService
{
    public static class Deserializer
    {
        public static List<Province> DeserializeProvinces(WilayahIdResponse wilayahIdResponse)
        {
            List<Province> provinces = wilayahIdResponse.Data
                .Select(province => new Province(province.Code, province.Name))
                .OrderByProvinceCode();

            return provinces;
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
