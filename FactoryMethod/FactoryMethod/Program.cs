
var nameTransport = Console.ReadLine();

var logistic = GetLogistics(nameTransport);

var transport = logistic.CreateTransport();

transport.Deliver();

Console.ReadKey();

Logistics GetLogistics(string nameTransport)
{
    return nameTransport switch
    {
        "трак" => new RoadLogistics(),
        "карабль" => new SeaLogistics(),
        _ => throw new NotImplementedException(),
    };
}


abstract class Logistics
{
    abstract public ITransport CreateTransport();
}

class RoadLogistics : Logistics
{
    public override ITransport CreateTransport()
    {
        return new Truck();
    }
}

class SeaLogistics : Logistics
{
    public override ITransport CreateTransport()
    {
        return new Ship();
    }
}

interface ITransport
{
    void Deliver();
}

class Truck : ITransport
{
    public void Deliver()
    {
        Console.WriteLine("Доставим груз грузовиком по суше");
    }
}

class Ship : ITransport
{
    public void Deliver()
    {
        Console.WriteLine("Доставим груз судном по морю");
    }
}
