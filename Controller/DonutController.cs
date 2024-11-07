using Microsoft.AspNetCore.Mvc;

namespace e_commerce.Models;

public class DonutController : Controller
{
    private readonly IDonutRepository _donutRepository;
    private readonly ICategoryRepository _categoryRepository;

    public DonutController(IDonutRepository donutRepository, ICategoryRepository categoryRepository)
    {
        _donutRepository = donutRepository;
        _categoryRepository = categoryRepository;
    }

    public IActionResult List()
    {
        ViewBag.CurrentCategory = "Cake Donuts";

        return View(_donutRepository.AllDonuts);
    }



}
