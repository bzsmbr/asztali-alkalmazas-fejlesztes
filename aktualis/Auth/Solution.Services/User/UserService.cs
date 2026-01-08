namespace Solution.Services.User;

public class UserService(UserManager<UserEntity> userManager) : IUserService
{
    public async Task<ErrorOr<ICollection<UserModel>>> GetAllUsers()
    { 
        return await userManager.Users.Select(x=> new UserModel
        { 
            Email = x.Email,
            Name = x.FullName
        })
        .ToListAsync();
    }
}
