using System.Text.Json.Serialization;
using IndonesianAdministrativeArea.Extensions;
using IndonesianAdministrativeArea.Models.Dtos;

namespace IndonesianAdministrativeArea.Models.UnitOfArea;

public record VillageProper
{
    private readonly string _id;
    private readonly string _type = "Kelurahan/Desa";
    private readonly string _name;
    private readonly VillageContext _context;
    private readonly string _fullPath;

    [JsonPropertyName("id")]
    public string Id => _id;

    [JsonPropertyName("type")]
    public string Type => _type;

    [JsonPropertyName("name")]
    public string Name => _name;

    [JsonPropertyName("context")]
    public VillageContext Context => _context;

    [JsonPropertyName("full_path")]
    public string FullPath => _fullPath;

    [JsonIgnore] string KelurahanDesa => $"{_type.TruncateType()} {_name}";
    [JsonIgnore] string Kecamatan => $"Kec. {_context.District}";
    [JsonIgnore] string KabupatenKota => $"{Context.Regency.type.TruncateType()} {Context.Regency.name}";
    [JsonIgnore] string Provinsi => _context.Province;

    public VillageProper(VillageDto villageDto,
        DistrictDto districtDto, RegencyDto regencyDto, ProvinceDto provinceDto)
    {
        _id = villageDto.Code;
        _type = GetVillageType();
        _name = villageDto.Name;
        _context = new VillageContext(districtDto.Name,
            regencyDto.Name.SplitRegencyType(), provinceDto.Name);
        _fullPath = $"{KelurahanDesa}, {Kecamatan}, {KabupatenKota}, {Provinsi}";
    }

    [JsonConstructor]
    public VillageProper(string id, string type, string name,
        string district, string regency, string province, string fullPath)
    {
        _id = id.NormalizeId();
        _type = type;
        _name = name;
        _context = new VillageContext(district, regency.SplitRegencyType(), province);
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

public record VillageContext
{
    private readonly string _district;
    private readonly (string type, string name) _regency;
    private readonly string _province;

    [JsonPropertyName("district")]
    public string District => _district;

    [JsonIgnore]
    public (string type, string name) Regency => _regency;

    [JsonPropertyName("regency")]
    public string RegencyStr => $"{_regency.type} {_regency.name}";

    [JsonPropertyName("province")]
    public string Province => _province;

    [JsonConstructor]
    public VillageContext(string district, (string, string) regency, string province)
    {
        _district = district;
        _regency = regency;
        _province = province;
    }
}
