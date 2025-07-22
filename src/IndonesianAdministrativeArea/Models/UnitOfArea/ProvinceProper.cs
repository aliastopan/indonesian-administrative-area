using System.Text.Json.Serialization;
using IndonesianAdministrativeArea.Models.Dtos;

namespace IndonesianAdministrativeArea.Models.UnitOfArea;

public record ProvinceProper
{
    private readonly string _id;
    private readonly string _type = "Provinsi";
    private readonly string _name;
    private readonly string _fullPath;

    [JsonPropertyName("id")]
    public string Id => _id;

    [JsonPropertyName("type")]
    public string Type => _type;

    [JsonPropertyName("name")]
    public string Name => _name;

    [JsonPropertyName("full_path")]
    public string FullPath => _fullPath;

    public ProvinceProper(ProvinceDto provinceDto)
    {
        _id = provinceDto.Code;
        _name = provinceDto.Name;
        _fullPath = _name;
    }
}
