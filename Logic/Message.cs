namespace Logic {
    public class Message : OwnedEntity {
        public override int Id {
            get;
            set;
        }

        public virtual string MessageBody {
            get;
            set;
        }

        public virtual string Subject {
            get;
            set;
        }
    }
}

