using Data.Entities;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Businesses.Services;

public interface IAuthService
{
    Task<bool> LoginAsync(MemberLoginForm loginform);
    Task LogoutAsync();
    Task<bool> SignUpAsync(MemberSignUpForm signupForm);
}

public class AuthService(SignInManager<MemberEntity> signInManager, UserManager<MemberEntity> userManager) : IAuthService
{
    private readonly SignInManager<MemberEntity> _signInManager = signInManager;
    private readonly UserManager<MemberEntity> _userManager = userManager;
    public async Task<bool> LoginAsync(MemberLoginForm loginform)
    {
        var user = await _userManager.FindByEmailAsync(loginform.Email);
        if (user == null)
            return false;

        var result = await _signInManager.PasswordSignInAsync(user.UserName, loginform.Password, false, false);
        return result.Succeeded;
    }

    public async Task<bool> SignUpAsync(MemberSignUpForm signupForm)
    {
        var memberEntity = new MemberEntity
        {
            UserName = signupForm.Email,
            FirstName = signupForm.FirstName,
            LastName = signupForm.LastName,
            Email = signupForm.Email,
            PhoneNumber = signupForm.Phone
        };

        var result = await _userManager.CreateAsync(memberEntity, signupForm.Password);
        return result.Succeeded;
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}
