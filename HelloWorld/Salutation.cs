namespace HelloWorld;

public class Salutation
{
    private readonly IMessageWriter _writer;

    public Salutation(IMessageWriter writer)
    {
        if (writer == null)
            throw new ArgumentNullException(nameof(writer));

        _writer = writer;
    }

    public void Exclaim()
    {
        _writer.Write("Hello DI!");
    }
}