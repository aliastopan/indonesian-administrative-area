using System.Text.Json.Serialization;
using IndonesianAdministrativeArea.Extensions;
using IndonesianAdministrativeArea.Models.Dtos;

namespace IndonesianAdministrativeArea.Models.UnitOfArea;

public record RegencyProper
{
    private readonly string _id;
    private readonly string _type = "Kabupaten/Kota";
    private readonly string _name;
    private readonly string _province;
    private readonly string _fullPath;

    [JsonPropertyName("id")]
    public string Code => _id;

    [JsonPropertyName("type")]
    public string Type => _type;

    [JsonPropertyName("name")]
    public string Name => _name;

    [JsonPropertyName("province")]
    public string Province => _province;

    [JsonPropertyName("full_path")]
    public string FullPath => _fullPath;

    public RegencyProper(RegencyDto regencyDto, ProvinceDto provinceDto)
    {
        (string type, string name) regency = regencyDto.Name.SplitRegencyType();

        _id = regencyDto.Code;
        _type = regency.type;
        _name = regency.name;
        _province = provinceDto.Name;
        _fullPath = $"{_type.TruncateType()} {_name}, {_province}";
    }
}
