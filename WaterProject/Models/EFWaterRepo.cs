
namespace WaterProject.Models
{
    public class EFWaterRepo : IWaterRepo
    {
        private WaterProjectContext _context;

        //constructor
        public EFWaterRepo(WaterProjectContext temp)
        {
            _context = temp;
        }
        public IQueryable<Project> Projects => _context.Projects;
    }
}
