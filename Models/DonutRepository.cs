using Microsoft.EntityFrameworkCore;

namespace e_commerce.Models
{
    public class DonutRepository : IDonutRepository
    {
        private readonly DoorStepDonutsDbContext _doorStepDonutsDbContext;

        public IEnumerable<Donut>? AllDonuts
        {
            get
            {
                return _doorStepDonutsDbContext?.Donuts?.Include(c => c.Category);
            }
        }

        public Donut? DonutOfTheDay
        {
            get
            {
                return _doorStepDonutsDbContext?.Donuts?.Include(c => c.Category).Where(d => d.IsDonutOfTheDay).FirstOrDefault();
            }
        }

        public Donut? GetDonutById(int donutId)
        {
            return _doorStepDonutsDbContext?.Donuts?.Include(c => c.Category).FirstOrDefault(d => d.DonutId == donutId);
        }

        public IEnumerable<Donut>? DonutsOfTheWeek
        {
            get
            {
                return _doorStepDonutsDbContext?.Donuts?.Include(c => c.Category).Where(d => d.IsDonutOfTheWeek);


            }
        }

        // registered with di container. using construction injection
        public DonutRepository(DoorStepDonutsDbContext doorStepDonutsDbContext)
        {
            _doorStepDonutsDbContext = doorStepDonutsDbContext;

        }










    }

}
