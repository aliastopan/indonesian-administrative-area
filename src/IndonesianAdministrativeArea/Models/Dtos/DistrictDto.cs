namespace IndonesianAdministrativeArea.Models.Dtos;

public class DistrictDto
{
    public string Code { get; init; }
    public string RegencyCode { get; init; }
    public string Name { get; init; }

    public DistrictDto(string code, string regencyCode, string name)
    {
        Code = code;
        RegencyCode = regencyCode;
        Name = name;
    }
}

