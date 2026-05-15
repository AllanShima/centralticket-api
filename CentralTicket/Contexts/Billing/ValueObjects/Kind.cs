namespace CentralTicket.Contexts.Billing.ValueObjects
{
    public class Kind
    {
        public int Value { get; private set; }

        enum Statuses
        {
            Default, // 0
            Vip,     // 1
            Cabin    // 2
        }

        public Kind(int value)
        {
            switch (value)
            {
                case (int)Statuses.Default:
                    this.Value = value;
                    break;
                case (int)Statuses.Vip:
                    this.Value = value;
                    break;
                case (int)Statuses.Cabin:
                    this.Value = value;
                    break;
                default:
                    throw new Exception("Status inválido.");
            }
        }

        public void Default() => this.Value = 0;

        public void Vip() => this.Value = 1;

        public void Cabin() => this.Value = 2;
    }
}
