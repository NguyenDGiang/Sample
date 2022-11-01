using Sample.Core.Dtos;

namespace Sample.Application.Services.Users
{
    public interface IUserService
    {
        Task<string> LoginAsync(LoginDto login);
    }
}
