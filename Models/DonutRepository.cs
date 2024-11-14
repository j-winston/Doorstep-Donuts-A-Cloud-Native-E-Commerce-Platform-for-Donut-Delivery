namespace e_commerce.Models
{
    public class DonutRepository : IDonutRepository
    {
        public IEnumerable<Donut> AllDonuts { get; } = new List<Donut>();

        public Donut GetDonutById(int donutId)
        {

            return new Donut();

        }






    }

}
