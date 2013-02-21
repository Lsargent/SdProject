using Logic;
using System.Data.Entity;

namespace DataAccess
{
    public class SdDb : DbContext 
    {
        public SdDb() : base("name = " + AppConfig.GetActiveConnectionString()) {
        }

        public DbSet<House> Houses { get; set; }
        public DbSet<Address> Addresses { get; set; }     
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
