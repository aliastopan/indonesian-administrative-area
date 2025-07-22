using System.Text.Json.Serialization;
using IndonesianAdministrativeArea.Models.Dtos;

namespace IndonesianAdministrativeArea.Models.UnitOfArea;

public record ProvinceProper
{
    private readonly string _code;
    private readonly string _type = "Provinsi";
    private readonly string _name;

    [JsonPropertyName("code")]
    public string Code => _code;

    [JsonPropertyName("type")]
    public string Type => _type;

    [JsonPropertyName("name")]
    public string Name => _name;

    public ProvinceProper(ProvinceDto provinceDto)
    {
        _code = provinceDto.Code;
        _name = provinceDto.Name;
    }
}
