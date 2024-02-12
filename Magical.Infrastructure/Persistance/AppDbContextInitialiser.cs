using Magical.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magical.Infrastructure.Persistance
{
    public class AppDbContextInitialiser
    {
        private readonly ILogger<AppDbContextInitialiser> _logger;
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AppDbContextInitialiser(
            ILogger<AppDbContextInitialiser> logger, 
            AppDbContext context,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                    await _context.Database.MigrateAsync(); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the databse.");
                throw;
            }
        }
        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the databse.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            //Default roles
            var administratorRole = new IdentityRole("Administrator");

            if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
                await _roleManager.CreateAsync(administratorRole);

            //Default users
            var administrator = new AppUser
            {
                UserName = "admin@magicalissue",
                Email = "admin@magicalissue"
            };

            if (_userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await _userManager.CreateAsync(administrator, "Administrator1!");
                if (!string.IsNullOrWhiteSpace(administratorRole.Name))
                    await _userManager.AddToRolesAsync(administrator,
                        new[] { administratorRole.Name } );
            }

            //mb latest will added default data
        }
    }
}
