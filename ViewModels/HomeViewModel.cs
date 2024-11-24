namespace e_commerce.ViewModels;
using e_commerce.Models;

public class HomeViewModel
{
    public IEnumerable<Donut>? DonutsOfTheWeek { get; }

    public HomeViewModel(IEnumerable<Donut> donutsOfTheWeek)
    {
        DonutsOfTheWeek = donutsOfTheWeek;
    }
}
