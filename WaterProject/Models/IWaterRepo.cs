namespace WaterProject.Models
{
    public interface IWaterRepo
    {
        public IQueryable<Project> Projects { get; }
    }
}
