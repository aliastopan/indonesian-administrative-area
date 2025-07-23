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
    [JsonIgnore] string KabupatenKota => $"{Context.RegencyTpl.type.TruncateType()} {Context.RegencyTpl.name}";
    [JsonIgnore] string Provinsi => Context.Province;

    public DistrictProper(DistrictDto districtDto, RegencyDto regencyDto, ProvinceDto provinceDto)
    {
        _id = districtDto.Code;
        _name = districtDto.Name;
        _context = new DistrictContext(regencyDto.Name, provinceDto.Name);
        _fullPath = $"{Kecamatan}, {KabupatenKota}, {Provinsi}";
    }

    [JsonConstructor]
    public DistrictProper(string id, string type, string name,
        DistrictContext context, string fullPath)
    {
        _id = id.NormalizeId();
        _type = type;
        _name = name;
        _context = context;
        _fullPath = fullPath;
    }
}

public record DistrictContext
{
    private readonly (string type, string name) _regencyTpl;
    private readonly string _province;

    [JsonIgnore]
    public (string type, string name) RegencyTpl => _regencyTpl;

    [JsonPropertyName("regency")]
    public string Regency => $"{_regencyTpl.type} {_regencyTpl.name}";

    [JsonPropertyName("province")]
    public string Province => _province;

    [JsonConstructor]
    public DistrictContext(string regency, string province)
    {
        _regencyTpl = regency.SplitRegencyType();
        _province = province;
    }
}
