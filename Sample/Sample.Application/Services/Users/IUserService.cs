using Sample.Shared.Dtos;

namespace Sample.Application.Services.Users
{
    public interface IUserService
    {
        Task<ReponseLoginDto> LoginAsync(LoginDto login);
    }
}
