using System.Text.Json.Serialization;
using IndonesianAdministrativeArea.Extensions;
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

    [JsonIgnore] string Provinsi => _name;

    public ProvinceProper(ProvinceDto provinceDto)
    {
        _id = provinceDto.Code;
        _name = provinceDto.Name;
        _fullPath = $"{Provinsi}";
    }

    [JsonConstructor]
    public ProvinceProper(string id, string type,string name, string fullPath)
    {
        _id = id.NormalizeId();
        _type = type;
        _name = name;
        _fullPath = fullPath;
    }
}
