namespace e_commerce.Controllers;

using Microsoft.AspNetCore.Mvc;
using e_commerce.Models;

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
        return View(_donutRepository.AllDonuts);
    }
}

