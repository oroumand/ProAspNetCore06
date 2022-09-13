using Microsoft.AspNetCore.Identity;

namespace AAASamples.Infra;

public class BlackListPasswordValidator<TUser> : IPasswordValidator<TUser>
    where TUser : IdentityUser
{
    private readonly List<string> _invalidPasswords = new List<string>
    {
        "password",
        "1qaz!QAZ",
        "@WSXXSW@",
        "qwerty",
        "test@test",
        "P@ssw0rd"
    };
    public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
    {
        if (_invalidPasswords.Any(c=>string.Equals(c,password,StringComparison.OrdinalIgnoreCase)))
        {
            return Task.FromResult(IdentityResult.Failed(new IdentityError
            {
                Code = " BlackListPassword",
                Description = "you can not use password in blacklist"
            }));
        }
        return Task.FromResult(IdentityResult.Success);
    }
}