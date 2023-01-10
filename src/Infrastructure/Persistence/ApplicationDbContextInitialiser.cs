using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieApi.Domain.Entities;
using MovieApi.Infrastructure.Identity;

namespace MovieApi.Infrastructure.Persistence;
public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
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
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
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
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new ApplicationRole("Administrator");

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default roles
        var financeRole = new ApplicationRole("FinanceUser");

        if (_roleManager.Roles.All(r => r.Name != financeRole.Name))
        {
            await _roleManager.CreateAsync(financeRole);
        }

        // Default users
        var administrator = new ApplicationUser
        {
            UserName = "administrator@localhost",
            Email = "administrator@localhost",
            Name = "Admin"
        };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name! });
        }

        // Finance default user
        var finance = new ApplicationUser
        {
            UserName = "fguerrero",
            Email = "fguerrero@gmail.com",
            Name = "Freddy",
            LastName = "Guerrero",
            DateOfBirth = new DateTime(1991, 4, 21)
        };

        if (_userManager.Users.All(u => u.UserName != finance.UserName))
        {
            await _userManager.CreateAsync(finance, "Administrator1!");
            await _userManager.AddToRolesAsync(finance, new[] { financeRole.Name! });
        }

        // Default data
        // Seed, if necessary
        if (!_context.TodoLists.Any())
        {
            _context.TodoLists.Add(new TodoList
            {
                Title = "Todo List",
                Items =
                {
                    new TodoItem { Title = "Make a todo list 📃" },
                    new TodoItem { Title = "Check off the first item ✅" },
                    new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
                    new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
                }
            });

            await _context.SaveChangesAsync();
        }

        if (!_context.Movies.Any())
        {
            _context.Movies.Add(new Movie
            {
                Title = "Test movie",
                Description = "Test movie description",
                Stock = 5,
                RentalPrice = 115,
                SalePrice = 1350,
                Availability = true
            });

            await _context.SaveChangesAsync();
        }
    }
}