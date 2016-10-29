using System.Data.Entity;
using HW5_MajorMinorForm.Models;

namespace HW5_MajorMinorForm.DAL
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
