namespace Decorator.Decorators;

public class SmsDecorator: BaseDecorator
{
    public SmsDecorator(Notifier wrappee) : base(wrappee)
    {
    }

    public override void Send(string message)
    {
        base.Send(message + "sms");
    }
}