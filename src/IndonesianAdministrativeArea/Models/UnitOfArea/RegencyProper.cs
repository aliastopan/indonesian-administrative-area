using System.Text.Json.Serialization;
using IndonesianAdministrativeArea.Extensions;
using IndonesianAdministrativeArea.Models.Dtos;

namespace IndonesianAdministrativeArea.Models.UnitOfArea;

public record RegencyProper
{
    private readonly string _id;
    private readonly string _type = "Kabupaten/Kota";
    private readonly (string type, string name) _regency;
    private readonly string _province;
    private readonly string _fullPath;

    [JsonPropertyName("id")]
    public string Code => _id;

    [JsonPropertyName("type")]
    public string Type => _type;

    [JsonPropertyName("name")]
    public string Name => _regency.name;

    [JsonPropertyName("province")]
    public string Province => _province;

    [JsonPropertyName("full_path")]
    public string FullPath => _fullPath;

    [JsonIgnore] string KabupatenKota => $"{_type.TruncateType()} {_regency.name}";
    [JsonIgnore] string Provinsi => _province;

    public RegencyProper(RegencyDto regencyDto, ProvinceDto provinceDto)
    {
        _regency = regencyDto.Name.SplitRegencyType();

        _id = regencyDto.Code;
        _type = _regency.type;
        _province = provinceDto.Name;
        _fullPath = $"{KabupatenKota}, {Provinsi}";
    }
}
