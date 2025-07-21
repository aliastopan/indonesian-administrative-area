namespace IndonesianAdministrativeArea.Models.Regions;

public class Province
{
    public string Code { get; init; }
    public string Name { get; init; }

    public Province(string code, string name)
    {
        Code = code;
        Name = name;
    }
}
