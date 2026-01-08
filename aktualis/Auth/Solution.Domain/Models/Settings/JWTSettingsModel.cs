namespace Solution.Domain.Models.Settings;

public class JWTSettingsModel
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public double DurationInMinutes { get; set; }
    public string Key { get; set; }
}
