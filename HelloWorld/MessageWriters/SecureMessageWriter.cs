using System.Security.Principal;

namespace HelloWorld.MessageWriters;

// Декоратор
// Пример того, как можно расширить функциональность при слабосвязанном коде
public class SecureMessageWriter : IMessageWriter // Реализация интерфейса с его же использованием
{
    private readonly IMessageWriter _writer;
    private readonly IIdentity _identity;

    public SecureMessageWriter(
        IMessageWriter writer,
        IIdentity identity)
    {
        if (writer is null)
            throw new ArgumentNullException(nameof(writer));
        if (identity is null)
            throw new ArgumentNullException(nameof(identity));

        _writer = writer;
        _identity = identity;
    }

    public void Write(string message)
    {
        // Проверка прохождения пользователем аутентификации
        if (_identity.IsAuthenticated)
        {
            // Если аутентификация пройдена, записывается сообщение с использованием внедрённого модуля записи  
            _writer.Write(message);
        }
    }
}