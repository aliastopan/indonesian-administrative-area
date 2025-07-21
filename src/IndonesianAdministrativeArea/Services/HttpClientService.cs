using System.Text.Json;
using IndonesianAdministrativeArea.Models.Contracts;

namespace IndonesianAdministrativeArea.Services;

public static class HttpClientService
{
    public static async Task<WilayahIdResponse?> GetAdministrativeArea(string url)
    {
        using var client = new HttpClient();
        try
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<WilayahIdResponse>(responseBody, GetOptions())!;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
            return null;
        }
        catch (JsonException e)
        {
            Console.WriteLine($"JSON parsing error: {e.Message}");
            return null;
        }

    }

    private static JsonSerializerOptions GetOptions()
    {
        return new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }
}
