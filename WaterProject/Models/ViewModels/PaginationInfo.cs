namespace WaterProject.Models.ViewModels
{
    //determines number of times build based on number of items
    public class PaginationInfo
    {
        
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        //like a dynamically set variable
        public int TotalNumPages => (int) (Math.Ceiling((decimal) TotalItems/ItemsPerPage));
        //if divide integer by integer get an integer so cast as decimal and then finally int
    }
}
