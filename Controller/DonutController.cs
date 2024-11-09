using Microsoft.AspNetCore.Mvc;
using e_commerce.ViewModels;

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
        var donutListViewModel = new DonutListViewModel(_donutRepository.AllDonuts, "Cake Donut");

        return View(donutListViewModel);

    }





}
