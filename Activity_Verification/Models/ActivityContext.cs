using Microsoft.EntityFrameworkCore;

namespace Activity_Verification.Models
{
    public class ActivityContext:DbContext
    {
        public ActivityContext(DbContextOptions<ActivityContext> options) : base(options) 
        {

        }

        public DbSet<Activity> Activities { get; set; }
    }
}
