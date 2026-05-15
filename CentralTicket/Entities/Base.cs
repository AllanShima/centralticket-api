namespace CentralTicket.Entities
{
    public class Base
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt {  get; private set; }

        public Base()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
    }
}
