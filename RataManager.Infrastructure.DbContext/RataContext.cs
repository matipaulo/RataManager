using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RataManager.Model;

namespace RataManager.Infrastructure.DbContext
{
    public class RataContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public RataContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
    }
}