namespace IndonesianAdministrativeArea.Models.Regions;

public class Village
{
    public string Code { get; init; }
    public string DistrictCode { get; init; }
    public string Name { get; init; }

    public Village(string code, string districtCode, string name)
    {
        Code = code;
        DistrictCode = districtCode;
        Name = name;
    }
}
