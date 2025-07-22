using System.Text.Json;

namespace IndonesianAdministrativeArea.Services;

public static class IndexService
{
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
