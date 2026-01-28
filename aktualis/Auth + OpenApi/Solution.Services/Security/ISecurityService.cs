namespace Solution.Services.Security;

public interface ISecurityService
{
    Task<ErrorOr<TokenResponseModel>> LoginAsync(LoginRequestModel model);
    Task<ErrorOr<Success>> RegisterAsync(RegisterRequestModel model);
}