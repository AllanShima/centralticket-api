namespace CentralTicket.Contexts.Events.ValueObjects;

public class Title
{
    public string Value { get; }

    public Title(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Título não pode ser vazio");

        if (value.Length < 3)
            throw new ArgumentException("Título deve ter ao menos 3 caracteres");

        if (value.Length > 100)
            throw new ArgumentException("Título não pode ter mais de 100 caracteres");

        Value = value.Trim();
    }

    public override string ToString() => Value;
}
