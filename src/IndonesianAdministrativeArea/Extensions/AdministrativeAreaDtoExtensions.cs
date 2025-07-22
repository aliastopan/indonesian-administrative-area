using IndonesianAdministrativeArea.Models.Dtos;
using IndonesianAdministrativeArea.Models.UnitOfArea;

namespace IndonesianAdministrativeArea.Extensions;

public static class AdministrativeAreaDtoExtensions
{
    public static List<ProvinceDto> OrderByProvinceCode(this IEnumerable<ProvinceDto> provinces)
    {
        return provinces
            .OrderBy(p => int.Parse(p.Code))
            .ToList();
    }

    public static List<RegencyDto> OrderByRegencyCode(this IEnumerable<RegencyDto> regencies)
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

    public static List<DistrictDto> OrderByDistrictCode(this IEnumerable<DistrictDto> districts)
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

    public static List<VillageDto> OrderByVillageCode(this IEnumerable<VillageDto> villages)
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

    public static List<ProvinceProper> MapProvinceDtosToPropers(this List<ProvinceDto> provinceDtos)
    {
        List<ProvinceProper> provinces = [];

        foreach (var dto in provinceDtos)
        {
            var province = new ProvinceProper(dto);

            provinces.Add(province);
        }

        return provinces;
    }

    public static List<RegencyProper> MapRegencyDtosToPropers(this List<RegencyDto> regencyDtos, List<ProvinceDto> provinceDtos)
    {
        List<RegencyProper> regencies = [];

        foreach (var dto in regencyDtos)
        {
            var provinceDto = provinceDtos.Find(p => dto.ProvinceCode == p.Code)
                ?? throw new NullReferenceException();

            var regency = new RegencyProper(dto, provinceDto!);

            regencies.Add(regency);
        }

        return regencies;
    }

    public static List<DistrictProper> MapDistrictDtosToPropers(this List<DistrictDto> districtDtos, List<RegencyDto> regencyDtos, List<ProvinceDto> provinceDtos)
    {
        List<DistrictProper> districts = [];

        foreach (var dto in districtDtos)
        {
            var provinceDto = provinceDtos.Find(p => dto.RegencyCode.GetProvinceCode() == p.Code)
                ?? throw new NullReferenceException();

            var regencyDto = regencyDtos.Find(r => dto.RegencyCode == r.Code)
                ?? throw new NullReferenceException();

            var district = new DistrictProper(dto, regencyDto, provinceDto);

            districts.Add(district);
        }

        return districts;
    }
}
