using Microsoft.AspNetCore.Mvc;
using e_commerce.ViewModels;
using e_commerce.Models;

namespace e_commerce.Controllers;

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

    public IActionResult Details(int id)
    {
        var donut = _donutRepository?.GetDonutById(id);


        if (donut == null)
            return NotFound();
        return View(donut);
    }
}
