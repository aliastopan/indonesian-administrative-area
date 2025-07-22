using System.Text.Json.Serialization;
using IndonesianAdministrativeArea.Extensions;
using IndonesianAdministrativeArea.Models.Dtos;

namespace IndonesianAdministrativeArea.Models.UnitOfArea;

public record DistrictProper
{
    private readonly string _id;
    private readonly string _type = "Kecamatan";
    private readonly string _name;
    private readonly (string type, string name) _regency;
    private readonly string _province;
    private readonly string _fullPath;

    [JsonPropertyName("id")]
    public string Code => _id;

    [JsonPropertyName("type")]
    public string Type => _type;

    [JsonPropertyName("name")]
    public string Name => _name;

    [JsonPropertyName("regency")]
    public string Regency => $"{_regency.type} {_regency.name}";

    [JsonPropertyName("province")]
    public string Province => _province;

    [JsonPropertyName("full_path")]
    public string FullPath => _fullPath;

    [JsonIgnore] string Kecamatan => $"Kec. {_name}";
    [JsonIgnore] string KabupatenKota => $"{_regency.type.TruncateType()} {_regency.name}";
    [JsonIgnore] string Provinsi => _province;

    public DistrictProper(DistrictDto districtDto, RegencyDto regencyDto, ProvinceDto provinceDto)
    {
        _regency = regencyDto.Name.SplitRegencyType();

        _id = districtDto.Code;
        _name = districtDto.Name;
        _province = provinceDto.Name;
        _fullPath = $"{Kecamatan}, {KabupatenKota}, {Provinsi}";
    }
}
