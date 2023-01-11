using Microsoft.Extensions.Configuration;
using Sample.Shared.Dtos;
using Sample.Shared.Helpers;
using Sample.DataAccess.Repositories.Users;
using Sample.Shared.Security;
using System.Security.Authentication;
using Sample.Application.Exceptions;

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
        public async Task<ReponseLoginDto> LoginAsync(LoginDto login)
        {
            var user = _userRepository.FindSingle(x => x.UserName.Equals(login.UserName));
            
            if(user == null)
            {
                throw new BadRequestException("User không tồn tại");
            }
            if (Cryptography.VerifyPassword(login.Password, user.StoreSalt, user.Password))
            {
                ReponseLoginDto reponseLoginDto = new ReponseLoginDto();
                reponseLoginDto.Token = JwtHelper.GenerateToken(user, _configuration);
                return reponseLoginDto;
            }
            //var signInResult = await _signInManager.PasswordSignInAsync(user, loginUserModel.Password, false, false);

            //if (!signInResult.Succeeded)
            //{
            //    throw new BadRequestException("Username or password is incorrect");
            //}

            throw new AuthenticationException("Incorrect username or password");
        }
    }
}
