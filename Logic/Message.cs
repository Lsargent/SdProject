namespace Logic {
    public class Message : OwnedEntity {
        public virtual string MessageBody { get; set; }

        public virtual string Subject { get; set; }
    }
}