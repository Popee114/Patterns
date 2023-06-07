namespace Decorator.Decorators;

public class FacebookDecorator: BaseDecorator
{
    public FacebookDecorator(Notifier wrappee) : base(wrappee)
    {
    }

    public override void Send(string message)
    {
        base.Send(message + "facebook");
    }
}