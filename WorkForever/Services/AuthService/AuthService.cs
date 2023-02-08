using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using Azure;
using Microsoft.IdentityModel.Tokens;
using WorkForever.Dtos.User;
using WorkForever.Models;
using WorkForever.Repositories.UnitOfWork;

namespace WorkForever.Services.AuthService;

public class AuthService: IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    
    public AuthService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _configuration = configuration;
    }
    
    public async Task<ServiceResponse<string>> RegisterAsync(UserRegisterDto registeredUser)
    {
        var response = new ServiceResponse<string>();
        if (!await _unitOfWork.UserRepository.IsUsernameAvailableAsync(registeredUser.Username))
        {
            response.Success = false;
            response.Message = "Username is already taken";
            return response;
        }
        if (!await _unitOfWork.UserRepository.IsEmailAvailableAsync(registeredUser.Email))
        {
            response.Success = false;
            response.Message = "Email is already taken";
            return response;
        }
        CreatePasswordHash(registeredUser.Password, out byte [] passwordHash, out byte [] passwordSalt);
        var user = _mapper.Map<User>(registeredUser);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        
        await _unitOfWork.UserRepository.CreateAsync(user);
        await _unitOfWork.SaveAsync();
        response.Data = user.Id.ToString();
        return response;
    }

    public async Task<ServiceResponse<string>> LoginAsync(UserLoginDto userLogedIn)
    {
        var response = new ServiceResponse<string>();
        var user = await _unitOfWork.UserRepository.FindByUsernameAsync(userLogedIn.Username);
        if (user == null)
        {
            response.Success = false;
            response.Message = "User not found";
            return response;
        }
        if (!VerifyPasswordHash(userLogedIn.Password, user.PasswordHash, user.PasswordSalt))
        {
            response.Success = false;
            response.Message = "Wrong password";
            return response;
        }
        response.Data = CreateToken(user);
        return response;
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        {
            var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computeHash.SequenceEqual(passwordHash);
        }
    }

    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim> {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username)
        };

        SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
            .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = creds
        };

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}