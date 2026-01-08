using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Solution.Domain.Database.Entities;
using Solution.Domain.Models.Settings;
using System.ClientModel.Primitives;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Solution.Services.Security;

public class SecurityService(UserManager<UserEntity> userManager, IOptions<JWTSettingsModel> setting) : ISecurityService
{
    public async Task<ErrorOr<Success>> RegisterAsync(RegisterRequestModel model)
    {
        //TODO: Add validations
        var result = await userManager.CreateAsync(new UserEntity
        { 
            Email = model.Email,
            EmailConfirmed = true,
            FullName = $"{model.FirstName} {model.LastName}",
            PhoneNumber = model.PhoneNumber,
            PhoneNumberConfirmed = true,
            UserName = $"{model.FirstName}.{model.LastName}",
        },model.Password);

        var errors = result.Errors.Select(x => x.Description));
        return result.Succeeded ? 
            Result.Success : 
            Error.Failure(description: string.Join(", ", errors));
    }

    public async Task<ErrorOr<TokenResponseModel>> LoginAsync(LoginRequestModel model)
    {
        //TODO: execute validation
        var user = await userManager.FindByEmailAsync(model.Email);
        if (user is null)
        {
            return Error.Unauthorized(description: "Invalid credentials");
        }
        var isPasswordValid = await userManager.CheckPasswordAsync(user, model.Password);

        return isPasswordValid ? 
            await GetTokenAsync(user) : 
            Error.Unauthorized(description: "Invalid credentials");
    }

    private async Task<ErrorOr<TokenResponseModel>> GetTokenAsync(UserEntity user)
    {
        var roles = await userManager.GetRolesAsync(user);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(setting.Value.Key));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiration = DateTime.UtcNow.AddMinutes(setting.Value.DurationInMinutes);

        var token = new JwtSecurityToken(
            issuer: setting.Value.Issuer,
            audience: setting.Value.Audience,
            claims: claims,
            expires: expiration,
            signingCredentials: credentials);

        return new TokenResponseModel
        {
            Roles = roles,
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            TokenExpirationTime = expiration
        };

    }
};