using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LMS.Application.Exception;
using LMS.Domain.Interface;
using LMS.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LMS.Infrastructure.Repository
{
    public class AuthRepository : IAuthRepository
    {
        readonly UserManager<Member> _userManager;
        readonly SignInManager<Member> _signInManger;
        readonly JwtSettings _jwtSettings;

        //constrcutor
        public AuthRepository(UserManager<Member> userManager, SignInManager<Member> signInManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManger = signInManager;
            _jwtSettings = jwtSettings.Value;

        }
        public async Task<AuthResponse> Login(AuthRequest authRequest)
        {
            var user = await _userManager.FindByEmailAsync(authRequest.Email);
            if (user == null)
            {
                throw new NotFoundException($"user with Email {authRequest.Email} not exists");
            }
            var userPassword = await _signInManger.CheckPasswordSignInAsync(user, authRequest.Password, false);
            if (userPassword.Succeeded == false)
            {
                throw new BadRequestException($" password Credentials are wrong");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.ToList()[0];
            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
            var response = new AuthResponse
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Role = role,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };
            return response;
        }

        private async Task<JwtSecurityToken> GenerateToken(Member user)
        {
            //Get User Information from Db
            var userClaims = await _userManager.GetClaimsAsync(user);
            //List of roles that user belongs To
            var roles = await _userManager.GetRolesAsync(user);
            //convert roles list into Claims
            //new Claim(claimTypes.Role,"Admin")

            var roleClaims = roles.Select(roles => new Claim(ClaimTypes.Role, roles)).ToList();
            //Create Claims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("mid",user.Id), 
            }
            .Union(userClaims)
            .Union(roleClaims);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials
                );
            return jwtSecurityToken;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest registrationRequest)
        {
            var user = new Member
            {
                Email = registrationRequest.Email,
                UserName = registrationRequest.Username,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, registrationRequest.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "member");
                return new RegistrationResponse() { UserId = user.Id };

            }
            else
            {
                var errorResult = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new BadRequestException($"{errorResult}");
            }

        }
    }
}
