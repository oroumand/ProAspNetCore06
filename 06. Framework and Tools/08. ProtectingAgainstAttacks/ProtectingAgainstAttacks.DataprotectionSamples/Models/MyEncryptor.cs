using Microsoft.AspNetCore.DataProtection;

namespace ProtectingAgainstAttacks.DataprotectionSamples.Models;

public class MyEncryptor
{
    private readonly IDataProtectionProvider _dataProtectionProvider;
    private readonly string purpose = "SampleNikamooz";
    public MyEncryptor(IDataProtectionProvider dataProtectionProvider)
	{
        _dataProtectionProvider = dataProtectionProvider;
    }

    public string Protect(string input)
    {
        var protector = _dataProtectionProvider.CreateProtector(purpose);
        return protector.Protect(input);
    }

    public string Unprotect(string input)
    {
        var protector = _dataProtectionProvider.CreateProtector(purpose);
        return protector.Unprotect(input);
    }
}
