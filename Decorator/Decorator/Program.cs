using Decorator;
using Decorator.Decorators;

Console.WriteLine("Декоратор вместо того, чтобы наследовать чью-либо функицональность - делегирует работу.");

var stack = new Notifier();

if (true)
    stack = new FacebookDecorator(stack);
if (true)
    stack = new SmsDecorator(stack);

stack.Send("Lol ");

Console.WriteLine("Hello, World!");