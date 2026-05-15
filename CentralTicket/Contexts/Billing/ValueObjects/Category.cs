namespace CentralTicket.Contexts.Billing.ValueObjects
{
    public class Category
    {
        public int Value { get; private set; }

        enum Statuses
        {
            HalfPrice, // 0
            FullPrice, // 1
        }

        public Category(int value)
        {
            switch (value)
            {
                case (int)Statuses.HalfPrice:
                    this.Value = value;
                    break;
                case (int)Statuses.FullPrice:
                    this.Value = value;
                    break;
                default:
                    throw new Exception("Status inválido.");
            }
        }

        public void HalfPrice() => this.Value = 0;

        public void FullPrice() => this.Value = 1;
    }
}
