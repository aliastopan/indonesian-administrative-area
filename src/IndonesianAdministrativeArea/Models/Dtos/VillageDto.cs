namespace IndonesianAdministrativeArea.Models.Dtos;

public class VillageDto
{
    public string Code { get; init; }
    public string DistrictCode { get; init; }
    public string Name { get; init; }

    public VillageDto(string code, string districtCode, string name)
    {
        Code = code;
        DistrictCode = districtCode;
        Name = name;
    }
}
