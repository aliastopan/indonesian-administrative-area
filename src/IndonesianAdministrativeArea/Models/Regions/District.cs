namespace IndonesianAdministrativeArea.Models.Regions;

public class District
{
    public string Code { get; init; }
    public string RegencyCode { get; init; }
    public string Name { get; init; }

    public District(string code, string regencyCode, string name)
    {
        Code = code;
        RegencyCode = regencyCode;
        Name = name;
    }
}

