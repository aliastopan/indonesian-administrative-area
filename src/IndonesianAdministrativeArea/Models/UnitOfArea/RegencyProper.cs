using System.Text.Json.Serialization;
using IndonesianAdministrativeArea.Extensions;
using IndonesianAdministrativeArea.Models.Dtos;

namespace IndonesianAdministrativeArea.Models.UnitOfArea;

public record RegencyProper
{
    private readonly string _id;
    private readonly string _type = "Kabupaten/Kota";
    private readonly (string type, string name) _regency;
    private readonly RegencyContext _context;
    private readonly string _fullPath;

    [JsonPropertyName("id")]
    public string Id => _id;

    [JsonPropertyName("type")]
    public string Type => _type;

    [JsonPropertyName("name")]
    public string Name => _regency.name;

    [JsonPropertyName("context")]
    public RegencyContext Context => _context;

    [JsonPropertyName("full_path")]
    public string FullPath => _fullPath;

    [JsonIgnore] string KabupatenKota => $"{_type.TruncateType()} {_regency.name}";
    [JsonIgnore] string Provinsi => _context.Province;

    public RegencyProper(RegencyDto regencyDto, ProvinceDto provinceDto)
    {
        _regency = regencyDto.Name.SplitRegencyType();

        _id = regencyDto.Code;
        _type = _regency.type;
        _context = new RegencyContext(provinceDto.Name);
        _fullPath = $"{KabupatenKota}, {Provinsi}";
    }

    [JsonConstructor]
    public RegencyProper(string id, string type, string name,
        RegencyContext context, string fullPath)
    {
        _id = id.NormalizeId();
        _regency = (type, name);
        _context = context;
        _fullPath = fullPath;
    }
}

public record RegencyContext
{
    private readonly string _province;

    [JsonPropertyName("province")]
    public string Province => _province;

    [JsonConstructor]
    public RegencyContext(string province)
    {
        _province = province;
    }
}