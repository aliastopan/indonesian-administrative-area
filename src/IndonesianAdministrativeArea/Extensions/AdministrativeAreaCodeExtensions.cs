namespace IndonesianAdministrativeArea.Extensions;

public static class AdministrativeAreaCodeExtensions
{
    public static string GetProvinceCode(this string code)
    {
        var parts = code.Split('.');
        if (parts.Length < 1 || string.IsNullOrWhiteSpace(parts[0]))
            throw new ArgumentException($"Invalid BPS code for Province: \"{code}\"");

        return parts[0];
    }

    public static string GetRegencyCode(this string code)
    {
        var parts = code.Split('.');
        if (parts.Length < 2)
            throw new ArgumentException($"Invalid BPS code for Regency: \"{code}\"");

        return $"{parts[0]}.{parts[1]}";
    }

    public static string GetDistrictCode(this string code)
    {
        var parts = code.Split('.');
        if (parts.Length < 3)
            throw new ArgumentException($"Invalid BPS code for District: \"{code}\"");

        return $"{parts[0]}.{parts[1]}.{parts[2]}";
    }
}
