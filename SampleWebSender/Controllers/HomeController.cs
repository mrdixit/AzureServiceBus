using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SampleShared;
using SampleWebSender.Models;
using SampleWebSender.Services;

namespace SampleWebSender.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IAzureBusService azureBusService;

    public HomeController(ILogger<HomeController> logger, IAzureBusService busService)
    {
        _logger = logger;
        this.azureBusService = busService;
    }

    [HttpPost]
    public async Task<IActionResult> Index(Person person)
    {
        await azureBusService.SendMessageAsync(person, "AzureQueueNameHere");
        return RedirectToAction("Privacy");
    }

    public IActionResult Index()
    {

        return View();
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
