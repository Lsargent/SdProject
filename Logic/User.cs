using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic {
    public class User : IObjectState {
        public int Id { get; set; }

        public string UserName { get; set; }

        public virtual List<House> Houses { get; set; }

        public virtual Address PrimaryAddress { get; set; }

        public virtual List<Friend> Friends { get; set; }

        public virtual List<Image> Images { get; set; }

        public virtual Entity Entity { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}

