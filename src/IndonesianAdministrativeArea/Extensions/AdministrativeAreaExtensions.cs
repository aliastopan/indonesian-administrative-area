using IndonesianAdministrativeArea.Models.Regions;

namespace IndonesianAdministrativeArea.Extensions;

public static class AdministrativeAreaExtensions
{
    public static List<Province> OrderByProvinceCode(this IEnumerable<Province> provinces)
    {
        return provinces
            .OrderBy(p => int.Parse(p.Code))
            .ToList();
    }
}
