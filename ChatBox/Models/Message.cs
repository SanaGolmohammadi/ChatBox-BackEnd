namespace ChatBox.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Box { get; set; }
        public string Sender { get; set; }
        public DateTime SentAt { get; set; }
    }
}
