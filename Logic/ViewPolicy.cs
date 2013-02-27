namespace Logic {
    public class ViewPolicy {
        public int Id { get; set; }

        public string Policy { get; set; }

        public virtual Entity Entity { get; set; }
    }
}