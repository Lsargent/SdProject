using Logic;
using System.Data.Entity;

namespace DataAccess
{
    public class SdDb : DbContext 
    {
        public DbSet<House> Houses { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
