namespace e_commerce.Models;

public interface IDonutRepository
{
    IEnumerable<Donut> AllDonuts { get; }
    Donut? GetDonutById(int donutId);

}
