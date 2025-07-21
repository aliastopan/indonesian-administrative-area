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

    public static List<Regency> OrderByRegencyCode(this IEnumerable<Regency> regencies)
    {
        return regencies
            .OrderBy(r =>
            {
                var parts = r.Code.Split('.');
                if (parts.Length < 2)
                    throw new ArgumentException($"Invalid regency BPS code: \"{r.Code}\"");

                (int ProvincePart, int RegencyPart) BpsCode = (
                    int.Parse(parts[0]),
                    int.Parse(parts[1]));

                return BpsCode;
            })
            .ToList();
    }

    public static List<District> OrderByDistrictCode(this IEnumerable<District> districts)
    {
        return districts
            .OrderBy(d =>
            {
                var parts = d.Code.Split('.');
                if (parts.Length < 3)
                    throw new ArgumentException($"Invalid district BPS code: \"{d.Code}\"");

                (int ProvincePart, int RegencyPart, int DistrictPart) BpsCode = (
                    int.Parse(parts[0]),
                    int.Parse(parts[1]),
                    int.Parse(parts[2]));

                return BpsCode;
            })
            .ToList();
    }

    public static List<Village> OrderByVillageCode(this IEnumerable<Village> villages)
    {
        return villages
            .OrderBy(v =>
            {
                var parts = v.Code.Split('.');
                if (parts.Length < 4)
                    throw new ArgumentException($"Invalid village BPS code: \"{v.Code}\"");

                (int ProvincePart, int RegencyPart, int DistrictPart, int VillagePart) BpsCode = (
                    int.Parse(parts[0]),
                    int.Parse(parts[1]),
                    int.Parse(parts[2]),
                    int.Parse(parts[3]));

                return BpsCode;
            })
            .ToList();
    }
}
