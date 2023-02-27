using Microsoft.Extensions.Configuration;
using Sample.Shared.Dtos;
using Sample.Shared.Helpers;
using Sample.DataAccess.Repositories.Users;
using Sample.Shared.Security;
using System.Security.Authentication;
using Sample.Application.Exceptions;
using Sample.Core.Entities;
using Sample.DataAccess.Repositories.RefreshTokens;
using Sample.Shared.SeedWorks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Sample.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository, 
            IConfiguration configuration,
            IRefreshTokenRepository refreshTokenRepository)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _refreshTokenRepository = refreshTokenRepository;
        }
        public async Task<ApiResult> LoginAsync(LoginDto login)
        {
            var user = _userRepository.FindSingle(x => x.UserName.Equals(login.UserName));
            
            if(user == null)
            {
                throw new BadRequestException("User không tồn tại");
            }
            if (Cryptography.VerifyPassword(login.Password, user.StoreSalt, user.Password))
            {
                var Token = JwtHelper.GenerateToken(user, _configuration);
                var refreshToken = new RefreshToken()
                {
                    JwtId = Token,
                    IsUsed = false,
                    UserId = user.Id,
                    AddedDate = DateTime.UtcNow,
                    ExpiryDate = DateTime.UtcNow.AddYears(1),
                    IsRevoked = false,
                    Token = RandomString(25) + Guid.NewGuid()
                };
                _refreshTokenRepository.Add(refreshToken);
                return new ApiResult() {IsSuccess = true, RefreshToken = refreshToken.Token, Token =  Token};
            }

            //var signInResult = await _signInManager.PasswordSignInAsync(user, loginUserModel.Password, false, false);

            //if (!signInResult.Succeeded)
            //{
            //    throw new BadRequestException("Username or password is incorrect");
            //}
            

            throw new AuthenticationException("Incorrect username or password");
        }
        public string RandomString(int length)
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public async Task<ApiResult> VerifyToken(TokenRequest tokenRequest)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            try
            {
                // This validation function will make sure that the token meets the validation parameters
                // and its an actual jwt token not just a random string
                var key = Encoding.ASCII.GetBytes("401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1");
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                    ValidateLifetime = false, //here we are saying that we don't care about the token's expiration date
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Audience"]
                };

                var principal = jwtTokenHandler.ValidateToken(tokenRequest.Token, tokenValidationParameters, out var securityToken);
                // Now we need to check if the token has a valid security algorithm
                if (securityToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

                    if (result == false)
                    {
                        return null;
                    }
                }

                // Will get the time stamp in unix time
                var utcExpiryDate = long.Parse(principal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                // we convert the expiry date from seconds to the date
                var expDate = UnixTimeStampToDateTime(utcExpiryDate);

                if (expDate > DateTime.UtcNow)
                {
                    return new ApiResult(false, "We cannot refresh this since the token has not expired", 400);
                }

                // Check the token we got if its saved in the db
                var storedRefreshToken = _refreshTokenRepository.FindAll().FirstOrDefault(x => x.Token == tokenRequest.RefreshToken);

                if (storedRefreshToken == null)
                {
                    return new ApiResult()
                    {
                       Message  =  "refresh token doesnt exist" ,
                       IsSuccess = false
                    };
                }

                // Check the date of the saved token if it has expired
                if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
                {
                    return new ApiResult()
                    {
                        Message = "token has expired, user needs to relogin",
                        IsSuccess = false
                    };
                }

                // check if the refresh token has been used
                if (storedRefreshToken.IsUsed)
                {
                    return new ApiResult()
                    {
                        Message = "token has been used",
                        IsSuccess = false
                    };
                }

                // Check if the token is revoked
                if (storedRefreshToken.IsRevoked)
                {
                    return new ApiResult()
                    {
                        Message = "token has been revoked",
                        IsSuccess = false
                    };
                }
                storedRefreshToken.IsUsed = true;
                _refreshTokenRepository.Update(storedRefreshToken);

                var dbUser = _userRepository.FindById(storedRefreshToken.UserId);
                var Token = JwtHelper.GenerateToken(dbUser, _configuration);
                var refreshToken = new RefreshToken()
                {
                    JwtId = Token,
                    IsUsed = false,
                    UserId = dbUser.Id,
                    AddedDate = DateTime.UtcNow,
                    ExpiryDate = DateTime.UtcNow.AddYears(1),
                    IsRevoked = false,
                    Token = RandomString(25) + Guid.NewGuid()
                };
                _refreshTokenRepository.Add(refreshToken);
                return new ApiResult() { IsSuccess = true, RefreshToken = refreshToken.Token, Token = Token };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToUniversalTime();
            return dtDateTime;
        }
    }
}
