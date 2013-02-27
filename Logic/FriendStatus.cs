namespace Logic {
    public class FriendStatus {
        public int Id { get; set; }

        public string Value { get; set; }

        public virtual Entity Entity { get; set; }
    }
}