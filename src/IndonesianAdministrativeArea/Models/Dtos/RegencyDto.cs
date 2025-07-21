namespace IndonesianAdministrativeArea.Models.Dtos;

public class RegencyDto
{
    public string Code { get; init; }
    public string ProvinceCode { get; init; }
    public string Name { get; init; }

    public RegencyDto(string code, string provinceCode, string name)
    {
        Code = code;
        ProvinceCode = provinceCode;
        Name = name;
    }
}
