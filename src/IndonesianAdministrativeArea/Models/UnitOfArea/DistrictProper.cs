using System.Text.Json.Serialization;
using IndonesianAdministrativeArea.Extensions;
using IndonesianAdministrativeArea.Models.Dtos;

namespace IndonesianAdministrativeArea.Models.UnitOfArea;

public record DistrictProper
{
    private readonly string _id;
    private readonly string _type = "Kecamatan";
    private readonly string _name;
    private readonly DistrictContext _context;
    private readonly string _fullPath;

    [JsonPropertyName("id")]
    public string Id => _id;

    [JsonPropertyName("type")]
    public string Type => _type;

    [JsonPropertyName("name")]
    public string Name => _name;

    [JsonPropertyName("context")]
    public DistrictContext Context => _context;

    [JsonPropertyName("full_path")]
    public string FullPath => _fullPath;

    [JsonIgnore] string Kecamatan => $"Kec. {_name}";
    [JsonIgnore] string KabupatenKota => $"{Context.Regency.type.TruncateType()} {Context.Regency.name}";
    [JsonIgnore] string Provinsi => Context.Province;

    public DistrictProper(DistrictDto districtDto, RegencyDto regencyDto, ProvinceDto provinceDto)
    {
        _id = districtDto.Code;
        _name = districtDto.Name;
        _context = new DistrictContext(regencyDto.Name.SplitRegencyType(), provinceDto.Name);
        _fullPath = $"{Kecamatan}, {KabupatenKota}, {Provinsi}";
    }

    [JsonConstructor]
    public DistrictProper(string id, string type, string name,
        string regency, string province, string fullPath)
    {
        _id = id.NormalizeId();
        _type = type;
        _name = name;
        _context = new DistrictContext(regency.SplitRegencyType(), province);
        _fullPath = fullPath;
    }
}

public record DistrictContext
{
    private readonly (string type, string name) _regency;
    private readonly string _province;

    [JsonIgnore]
    public (string type, string name) Regency => _regency;

    [JsonPropertyName("regency")]
    public string RegencyStr => $"{_regency.type} {_regency.name}";

    [JsonPropertyName("province")]
    public string Province => _province;


    [JsonConstructor]
    public DistrictContext((string, string) regency, string province)
    {
        _regency = regency;
        _province = province;
    }
}
