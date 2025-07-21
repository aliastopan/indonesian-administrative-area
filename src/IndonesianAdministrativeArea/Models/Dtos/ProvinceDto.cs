namespace IndonesianAdministrativeArea.Models.Dtos;

public class ProvinceDto
{
    public string Code { get; init; }
    public string Name { get; init; }

    public ProvinceDto(string code, string name)
    {
        Code = code;
        Name = name;
    }
}
