using System.Security.Principal;
using HelloWorld.MessageWriters;

namespace HelloWorld;

public class Program
{
    public static void Main(string[] args)
    {
        // Пример расширяемости кода со слабой связанностью
        // ConsoleMessageWriter перехватывается декоратором SecureMessageWriter
        IMessageWriter writer =
            new SecureMessageWriter(
                new ConsoleMessageWriter(),
                WindowsIdentity.GetCurrent());
        
        // Пример внедрения зависимости через конструктор
        var salutation = new Salutation(writer);
        salutation.Exclaim();
    }
}