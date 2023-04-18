using admin.ViewModels;

namespace admin.Services
{
    public class CareerMapsService
    {
        public List<CareerMapVM> GetAllCareers()
        {
            var careers = new List<CareerMapVM>();

            for (int i = 1; i <= 5; i++)
            {
                careers.Add(new CareerMapVM()
                {
                    CareerMapId = i,
                    CareerMapName = $"Carreira {i}"
                });
            };
            return careers;
        }
    }
}
