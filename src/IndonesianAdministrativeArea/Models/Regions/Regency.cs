namespace IndonesianAdministrativeArea.Models.Regions;

public class Regency
{
    public string Code { get; init; }
    public string ProvinceCode { get; init; }
    public string Name { get; init; }

    public Regency(string code, string provinceCode, string name)
    {
        Code = code;
        ProvinceCode = provinceCode;
        Name = name;
    }
}
