using System.Diagnostics;
using BLL.Extensions;
using BLL.Services.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyMessenger.Models;

namespace MyMessenger.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private UserManager<User> _userManager;
    public HomeController(ILogger<HomeController> logger,  UserManager<User> userManager)
    {
        _userManager = userManager;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var userIdentity = User.Identity;
        if (userIdentity is { IsAuthenticated: true })
            return Redirect("/chat");

        return View();
    }

    public async Task<IActionResult> Profile()
    {
        var userIdentity = User.Identity;
        if (userIdentity != null)
        {
            var user = await _userManager.GetUserByClaimsIdentityNameAsync(userIdentity);
            UserDto userDto = new UserDto()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                LastName = user.LastName
            };
            return View(userDto);
        }

        return Redirect("/login");
    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}