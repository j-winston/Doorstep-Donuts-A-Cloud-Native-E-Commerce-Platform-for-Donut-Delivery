namespace e_commerce.Controllers;

using Microsoft.AspNetCore.Mvc;
using e_commerce.Models;
using e_commerce.ViewModels;

public class HomeController : Controller
{
    private readonly IDonutRepository _donutRepository;
    private readonly ICategoryRepository _categoryRepository;

    public HomeController(IDonutRepository donutRepository, ICategoryRepository categoryRepository)
    {
        _donutRepository = donutRepository;
        _categoryRepository = categoryRepository;

    }

    public IActionResult Index()
    {
        var donutsOfTheWeek = _donutRepository?.DonutsOfTheWeek;
        var homeViewModel = new HomeViewModel(donutsOfTheWeek);

        return View(homeViewModel);
    }
}

