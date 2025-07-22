namespace IndonesianAdministrativeArea.Extensions;

public static class UnitOfAreaExtensions
{
    public static string TruncateType(this string type)
    {
        // type:
        // Kabupaten
        // Kota
        // Kecamatan

        if (type.Length > 4)
        {
            var truncated = type.Substring(0, 3);

            return $"{truncated}.";
        }

        return type;
    }

    public static (string type, string name) SplitRegencyType(this string regency)
    {
        string[] parts = regency.Split(' ');
        string type = parts[0];
        string name = string.Join(" ", parts.Skip(1));

        return (type, name);
    }
}
