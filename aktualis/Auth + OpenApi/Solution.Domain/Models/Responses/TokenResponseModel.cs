namespace Solution.Domain.Models.Responses;

public class TokenResponseModel
{
    [Required]
    [JsonPropertyName("roles")]
    public IList<string> Roles { get; set; } = [];

    [Required]
    [JsonPropertyName("token")]
    public string Token { get; set; }

    [Required]
    [JsonPropertyName("tokenExpirationTime")]
    public DateTime TokenExpirationTime { get; set; }
}
