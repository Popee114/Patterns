namespace Decorator;

public class BaseDecorator : Notifier
{
    private Notifier _wrappee;

    protected BaseDecorator(Notifier wrappee)
    {
        _wrappee = wrappee;
    }

    public override void Send(string message)
    {
        _wrappee.Send(message);
    }
}