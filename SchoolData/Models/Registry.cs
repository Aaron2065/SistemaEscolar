
namespace SchoolData.Models
{
    public class Registry 
    {
        public bool IsActive { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

        public DateTime HighSystem { get; set; } = DateTime.Now;
    }
}
