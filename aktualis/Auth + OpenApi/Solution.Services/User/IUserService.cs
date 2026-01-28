namespace Solution.Services.User;

public interface IUserService
{
    Task<ErrorOr<ICollection<UserModel>>> GetAllUsers();
}