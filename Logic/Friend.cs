namespace Logic {
    public class Friend : OwnedEntity {
        public virtual User Initiator {
            get;
            set;
        }

        public virtual User Reciever {
            get;
            set;
        }

        public virtual FriendStatus Status {
            get;
            set;
        }

        public override int Id {
            get;
            set;
        }

    }
}

