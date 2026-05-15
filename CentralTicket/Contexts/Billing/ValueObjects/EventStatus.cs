namespace CentralTicket.Contexts.Billing.ValueObjects
{
    public class EventStatus
    {
        public int Value { get; private set; }

        enum Statuses
        {
            Coming,     // 0
            InProgress, // 1
            Completed   // 2
        }

        public EventStatus(int value)
        {
            switch (value)
            {
                case (int)Statuses.Coming:
                    this.Value = value;
                    break;
                case (int)Statuses.InProgress:
                    this.Value = value;
                    break;
                case (int)Statuses.Completed:
                    this.Value = value;
                    break;
                default:
                    throw new Exception("Status inválido.");
            }
        }

        public void Coming() => this.Value = 0;
        
        public void InProgress() => this.Value = 1;
        
        public void Completed() => this.Value = 2;
    }
}
