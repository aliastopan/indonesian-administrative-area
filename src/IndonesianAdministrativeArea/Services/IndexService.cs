using System.Text.Json;
using IndonesianAdministrativeArea.Models.UnitOfArea;

namespace IndonesianAdministrativeArea.Services;

public static class IndexService
{
    public static void SerializeMeilisearchIndexJson(List<ProvinceProper> provinces,
        List<RegencyProper> regencies, List<DistrictProper> districts, List<VillageProper> villages)
    {
        int capacity = provinces.Count + regencies.Count + districts.Count + villages.Count;
        var meilisearchIndex = new List<object>(capacity);

        meilisearchIndex.AddRange(provinces);
        meilisearchIndex.AddRange(regencies);
        meilisearchIndex.AddRange(districts);
        meilisearchIndex.AddRange(villages);

        SerializeIndexJson(meilisearchIndex, "administrative-area.index.json");
    }

    public static void SerializeIndexJson<T>(List<T> administrativeArea, string fileName = "index.json")
    {
        string json = JsonSerializer.Serialize(administrativeArea, GetOptions());

        WriteIndexJson(fileName, json);
    }

    private static void WriteIndexJson(string fileName, string jsonBody)
    {
        string projectDir = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(projectDir, "..", "..", "data", "index", fileName);
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
