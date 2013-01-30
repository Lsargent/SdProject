using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SdDb : DbContext 
    {
        public DbSet<House> Houses { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
