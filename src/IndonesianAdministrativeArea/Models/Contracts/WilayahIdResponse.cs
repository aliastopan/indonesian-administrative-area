using System.Text.Json.Serialization;

namespace IndonesianAdministrativeArea.Models.Contracts;

public record WilayahIdResponse
{
    [JsonPropertyName("data")]
    public List<AdministrativeAreaData> Data { get; set; } = default!;

    [JsonPropertyName("meta")]
    public MetaData Meta { get; set; } = default!;
}

public record AdministrativeAreaData
{
    [JsonPropertyName("code")]
    public string Code { get; set; } = default!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;
}

public record MetaData
{
    [JsonPropertyName("administrative_area_level")]
    public int AdministrativeAreaLevel { get; set; }

    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; set; } = default!;
}