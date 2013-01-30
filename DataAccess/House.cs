using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class House
    {
        public int id { get; set; }
        public string HeatingType { get; set; }
        public int StoryCount { get; set; }
        public int RoomCount { get; set; }
        public double FloorSpace { get; set; }
        public virtual Address Address { get; set; }
    }
}
