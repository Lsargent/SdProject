using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic {
    public class User : Entity {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int UserId {
            get;
            set;
        }

        public virtual string UserName {
            get;
            set;
        }

        public virtual List<BaseComponent> Components {
            get;
            set;
        }

        public virtual Address PrimaryAddress {
            get;
            set;
        }

        public virtual List<Friend> Friends {
            get;
            set;
        }

        public override int Id {
            get;
            set;
        }

        public virtual List<Image> Images {
            get;
            set;
        }

    }
}

