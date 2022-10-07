using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AAASamples.Models;

public class AAADbContext : IdentityDbContext<CostumIdentityUser>
{
    public AAADbContext(DbContextOptions options) : base(options)
    {
    }
}


public class CostumIdentityUser:IdentityUser
{
    public string Name { get; set; }
    public string Family { get; set; }
}

