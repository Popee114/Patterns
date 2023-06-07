namespace Decorator.Decorators;

public class SlackDecorator : BaseDecorator
{
    public SlackDecorator(Notifier wrappee) : base(wrappee)
    {
    }

    public override void Send(string message)
    {
        base.Send(message + "slack");
    }
}