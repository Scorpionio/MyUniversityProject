using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ComputerDevicesShop.Models;
using ComputerDevicesShop.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ComputerDevicesShop.Models.DTOs;
using ComputerDevicesShop.Repositories;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace ComputerDevicesShop.Controllers;

public class HomeController : Controller
{
    private const string CookieName = "UserAuth";
    private readonly ICartRepository _cartRepo;
    private readonly IHomeRepository _homeRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    ApplicationDbContext _db;

    public HomeController(ApplicationDbContext context, ICartRepository cartRepo, IHomeRepository homeRepository, IHttpContextAccessor httpContextAccessor)
    {
        _db = context;
        _cartRepo = cartRepo;
        _homeRepository = homeRepository;
        _httpContextAccessor = httpContextAccessor;

    }

    public async Task<IActionResult> Index(string? sterm, int categoryId, string sortInfo)
    {
        if (Request.Cookies.TryGetValue(CookieName, out string username))
        {
            ViewBag.UserAuth = username;
        }
        IEnumerable<Device> devices = await _homeRepository.GetDevices(sterm, categoryId, sortInfo);
        IEnumerable<Category> categories = await _homeRepository.Categories();

        var model = new CatalogDTO
        {
            Devices = devices,
            Categories = categories,
            STerm = sterm,
            CategoryId = categoryId,
            SortInfo = sortInfo
        };
        return View(model);
    }


    //êàê îòîáğàçèòü ñòğàíèöó ïî èíäåêñó â áä
    public async Task<IActionResult> DeviñeCard(int id)
    {
        if (Request.Cookies.TryGetValue(CookieName, out string username))
        {
            ViewBag.UserAuth = username;
        }
        var device = _db.Devices.Find(id);
        var context = _httpContextAccessor.HttpContext;
        context.Request.Cookies.TryGetValue("UserAuth", out var CookieRole);
        User? user = null;
        if (CookieRole != null)
        {
            user = _db.Users.FirstOrDefault(u => u.Name == CookieRole);

        }
        var model = new DetailDTO
        {
            CategoryName = await _db.Categories
                .Where(c => c.CategoryId == device.CategoryId)
                .Select(c => c.Name)   // âûáèğàåì òîëüêî ïîëå Name
                .FirstOrDefaultAsync(),
            Device = device,
            User = user
        };
        return View(model);
    }
    public async Task<IActionResult> SaveRating(double rating, int deviceId)
    {
        int userId = _cartRepo.GetUserId();
        if (userId == null)
        {
            return RedirectToAction("Login", "Account");
        }
        Rate rate = await _db.Rates.FirstOrDefaultAsync(d => d.DeviceId == deviceId && d.UserId == userId);
        if (rate == null)
        {
            _db.Rates.Add(new Rate { DeviceId = deviceId, UserId = userId, Rateing = rating });
            await _db.SaveChangesAsync();
            Rate newRate = await _db.Rates.FirstOrDefaultAsync(d => d.DeviceId == deviceId && d.UserId == userId);
        }
        else 
        { 
            rate.Rateing = rating;
            await _db.SaveChangesAsync();
        }
        return RedirectToAction("Home", "DeviceCard");
    }
}







//  ÂÛÂÎÄ ÑĞÅÄÍÅÉ ÎÖÅÍÊÈ Â ÊÀÒÀËÎÃÅ

//  ÑÄÅËÀÒÜ ÎÒÎÁĞÀÆÅÍÈÅ ÎÖÅÍÊÈ ÏÎËÜÇÎÂÀÒÅËß ÍÀ ÅÃÎ ÒÎÂÀĞÅ

//  ÌÁ ÏÅĞÅÍÅÑÒÈ ÎÖÅÍÊÓ ÍÀ ÎÖÅÍÊÓ ÏĞÈ ÏÎÊÓÏÊÅ
