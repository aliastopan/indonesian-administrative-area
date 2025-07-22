using System.Text.Json.Serialization;
using IndonesianAdministrativeArea.Extensions;
using IndonesianAdministrativeArea.Models.Dtos;

namespace IndonesianAdministrativeArea.Models.UnitOfArea;

public record VillageProper
{
    private readonly string _id;
    private readonly string _type = "Kelurahan/Desa";
    private readonly string _name;
    private readonly string _district;
    private readonly (string type, string name) _regency;
    private readonly string _province;
    private readonly string _fullPath;

    [JsonPropertyName("id")]
    public string Id => _id;

    [JsonPropertyName("type")]
    public string Type => _type;

    [JsonPropertyName("name")]
    public string Name => _name;

    [JsonPropertyName("district")]
    public string District => _district;

    [JsonPropertyName("regency")]
    public string Regency => $"{_regency.type} {_regency.name}";

    [JsonPropertyName("province")]
    public string Province => _province;

    [JsonPropertyName("full_path")]
    public string FullPath => _fullPath;

    [JsonIgnore] string KelurahanDesa => $"{_type.TruncateType()} {_name}";
    [JsonIgnore] string Kecamatan => $"Kec. {_district}";
    [JsonIgnore] string KabupatenKota => $"{_regency.type.TruncateType()} {_regency.name}";
    [JsonIgnore] string Provinsi => _province;

    public VillageProper(VillageDto villageDto, DistrictDto districtDto, RegencyDto regencyDto, ProvinceDto provinceDto)
    {
        _regency = regencyDto.Name.SplitRegencyType();

        _id = villageDto.Code;
        _type = GetVillageType();
        _name = villageDto.Name;
        _district = districtDto.Name;
        _province = provinceDto.Name;
        _fullPath = $"{KelurahanDesa}, {Kecamatan}, {KabupatenKota}, {Provinsi}";
    }

    [JsonConstructor]
    public VillageProper(string id, string type, string name,
        string district, string regency, string province, string fullPath)
    {
        _id = id;
        _type = type;
        _name = name;
        _district = district;
        _regency = regency.SplitRegencyType();
        _province = province;
        _fullPath = fullPath;
    }

    private string GetVillageType()
    {
        string[] parts = _id.Split('.');

        if (parts.Length < 4)
            throw new ArgumentException();

        string code = parts[3];
        int firstDigit = int.Parse(code.First().ToString());

        return firstDigit == 1
            ? "Kelurahan"
            : "Desa";
    }
}
