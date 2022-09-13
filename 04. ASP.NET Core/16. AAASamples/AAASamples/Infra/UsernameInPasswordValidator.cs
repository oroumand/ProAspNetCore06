using AAASamples.Models;
using Microsoft.AspNetCore.Identity;

namespace AAASamples.Infra;

public class UsernameInPasswordValidator : IPasswordValidator<CostumIdentityUser>
{
    public Task<IdentityResult> ValidateAsync(UserManager<CostumIdentityUser> manager, CostumIdentityUser user, string password)
    {
        if(password.Contains(user.UserName,StringComparison.OrdinalIgnoreCase))
        {
            return Task.FromResult(IdentityResult.Failed(new IdentityError
            {
                Code = "UsernameInPassword",
                Description="you can not use your username in your password"
            }));
        }
        return Task.FromResult(IdentityResult.Success);
    }
}

public class CustomUserValidator : IUserValidator<CostumIdentityUser>
{
    private readonly string organizationEmail = "@nikamooz.com";
    public Task<IdentityResult> ValidateAsync(UserManager<CostumIdentityUser> manager, CostumIdentityUser user)
    {
        if (!user.Email.EndsWith(organizationEmail,StringComparison.OrdinalIgnoreCase))
        {
            return Task.FromResult(IdentityResult.Failed(new IdentityError
            {
                Code = "InvalidEmail",
                Description = "you should use your organizational email"
            }));
        }

        return Task.FromResult(IdentityResult.Success);

    }
}
