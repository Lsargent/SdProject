using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic {
    public class User : Entity {
        public virtual string UserName { get; set; }

        public virtual List<BaseComponent> Components { get; set; }

        public virtual Address PrimaryAddress { get; set; }

        public virtual List<Friend> Friends { get; set; }

        public virtual List<Image> Images { get; set; }
    }
}

