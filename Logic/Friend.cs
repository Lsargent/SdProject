namespace Logic {
    public class Friend {
        public int Id { get; set; }

        public virtual User Initiator { get; set; }

        public virtual User Reciever { get; set; }

        public virtual FriendStatus Status { get; set; }

        public virtual OwnedEntity OEntity { get; set; }
    }
}