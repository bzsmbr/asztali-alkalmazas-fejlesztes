namespace Solution.Services.Security;

public interface ISecurityService
{
    Task<ErrorOr<TokenResponseModel>> LoginAsync(LoginRequestModel model);

    Task<ErrorOr<TokenResponseModel>> RegisterAsync(RegisterRequestModel model);
}
