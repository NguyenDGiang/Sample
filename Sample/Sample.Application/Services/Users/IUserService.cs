using Sample.Shared.Dtos;
using Sample.Shared.SeedWorks;

namespace Sample.Application.Services.Users
{
    public interface IUserService
    {
        Task<ApiResult> LoginAsync(LoginDto login);
        Task<ApiResult> VerifyToken(TokenRequest tokenRequest);
    }
}
