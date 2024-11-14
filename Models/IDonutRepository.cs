namespace e_commerce.Models;

public interface IDonutRepository
{
    public IEnumerable<Donut> AllDonuts { get; }
    public Donut? GetDonutById(int donutId);

}
