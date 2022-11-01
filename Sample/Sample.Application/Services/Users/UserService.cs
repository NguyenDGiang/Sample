using Microsoft.Extensions.Configuration;
using Sample.Core.Dtos;
using Sample.Core.Helpers;
using Sample.DataAccess.Repositories.Users;
using Sample.Shared.Security;

namespace Sample.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration; 
        }
        public async Task<string> LoginAsync(LoginDto login)
        {
            var user = _userRepository.FindSingle(x => x.UserName.Equals(login.UserName));
            string? token ="";
            
            if(user == null)
            {
                throw new Exception("User không tồn tại");
            }
            if (!Cryptography.VerifyPassword(login.Password, user.StoreSalt, user.Password))
            {
                token = JwtHelper.GenerateToken(user, _configuration);
            }
            //var signInResult = await _signInManager.PasswordSignInAsync(user, loginUserModel.Password, false, false);

            //if (!signInResult.Succeeded)
            //{
            //    throw new BadRequestException("Username or password is incorrect");
            //}

            return token;
        }
    }
}
