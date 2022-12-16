using WorkForever.Dtos.User;
using WorkForever.Models;

namespace WorkForever.Services.AuthService;

public interface IAuthService
{
    Task<ServiceResponse<string>> RegisterAsync(UserRegisterDto userRegistered);
    Task<ServiceResponse<string>> LoginAsync(UserLoginDto userLogedIn);
    //Task<ServiceResponse<string>> ConfirmEmailAsync(string userId, string token);
    //Task<ServiceResponse<string>> ForgotPasswordAsync(string email);
    //Task<string> ResetPasswordAsync(string email, string token, string password);
}