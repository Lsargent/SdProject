namespace Logic {
    public class Message {
        public Message() {}

        public Message(string subject, string messageBody, OwnedEntityParams oEParams) {
            Subject = subject;
            MessageBody = messageBody;
            OwnedEntity = new OwnedEntity(oEParams);
        }

        public int Id { get; set; }

        public string MessageBody { get; set; }

        public string Subject { get; set; }

        public virtual OwnedEntity OwnedEntity { get; set; }
    }
}