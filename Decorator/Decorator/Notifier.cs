namespace Decorator;

public class Notifier
{
    public virtual void Send(string message)
    {
        Console.WriteLine(message);
    }
}