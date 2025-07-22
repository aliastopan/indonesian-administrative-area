using System.Text.Json.Serialization;
using IndonesianAdministrativeArea.Extensions;
using IndonesianAdministrativeArea.Models.Dtos;

namespace IndonesianAdministrativeArea.Models.UnitOfArea;

public record DistrictProper
{
    private readonly string _id;
    private readonly string _type = "Kecamatan";
    private readonly string _name;
    private readonly string _regency;
    private readonly string _province;
    private readonly string _fullPath;

    [JsonPropertyName("id")]
    public string Code => _id;

    [JsonPropertyName("type")]
    public string Type => _type;

    [JsonPropertyName("name")]
    public string Name => _name;

    [JsonPropertyName("regency")]
    public string Regency => _regency;

    [JsonPropertyName("province")]
    public string Province => _province;

    [JsonPropertyName("full_path")]
    public string FullPath => _fullPath;

    public DistrictProper(DistrictDto districtDto, RegencyDto regencyDto, ProvinceDto provinceDto)
    {
        (string type, string name) regency = regencyDto.Name.SplitRegencyType();

        _id = districtDto.Code;
        _name = districtDto.Name;
        _regency = regencyDto.Name;
        _province = provinceDto.Name;
        _fullPath = $"{_type.TruncateType()} {_name}, {regency.type.TruncateType()} {regency.name}, {_province}";
    }
}
