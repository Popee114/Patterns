
var kiaConveyor = new KiaConveyor();
var director = new MrPresident(kiaConveyor);
director.ConstractKia("Rio");
var kiaRio = kiaConveyor.GetCar();
kiaRio.GetInfo();

director.ConstractReno("Logan");

Console.ReadKey();

class MrPresident
{
    private KiaConveyor _kiaConveyor;

    private RenoConveyor _renoConveyor;

    public MrPresident(KiaConveyor kiaConveyor)
    {
        _kiaConveyor = kiaConveyor;
    }

    public MrPresident(RenoConveyor renoConveyor)
    {
        _renoConveyor = renoConveyor;
    }

    public void ConstractKia(string kiaName)
    {
        if (_kiaConveyor == null)
        {
            Console.WriteLine("Неможно. Нет конвейера.");
            return;
        }

        _kiaConveyor.SetName(kiaName);
        _kiaConveyor.BuildWheels();
    }

    public void ConstractReno(string renoName)
    {
        if (_renoConveyor == null)
        {
            Console.WriteLine("Неможно. Нет конвейера.");
            return;
        }

        _renoConveyor.SetName(renoName);
        _renoConveyor.BuildWheels();
    }
}

class Wheel
{
    public Wheel(string color, int diameter)
    {
        Color = color;
        Diameter = diameter;
    }

    public Wheel(Wheel wheel)
    {
        Color = wheel.Color;
        Diameter = wheel.Diameter;
    }

    public string Color { get; set; }

    public int Diameter { get; set; }

    public Wheel Clone => new Wheel(this);
}

interface ICar
{
    string Name { get; }

    List<Wheel> Wheels { get; set; }

    public void GetInfo();
}

class Kia : ICar
{
    public string Name { get; set; }

    public List<Wheel> Wheels { get; set; }

    public void GetInfo() 
    {
        Console.WriteLine($"Название - {Name}");
        for (var iterator = 0; iterator < 4; iterator++)
        {
            Console.WriteLine($"Колесо {iterator + 1} - Цвет {Wheels[iterator].Color}, Диаметр {Wheels[iterator].Diameter}");
        }
    }
}

class Reno : ICar
{
    public string Name { get; set; }

    public List<Wheel> Wheels { get; set; }

    public void GetInfo()
    {
        Console.WriteLine($"Название - {Name}");
        for (var iterator = 0; iterator < 4; iterator++)
        {
            Console.WriteLine($"Колесо {iterator + 1} - Цвет {Wheels[iterator].Color}, Диаметр {Wheels[iterator].Diameter}");
        }
    }
}

interface IConveyor<T> where T : ICar
{
    public void SetName(string kiaName);

    public void BuildWheels();

    public T GetCar();
}

class KiaConveyor : IConveyor<Kia>
{
    private Kia _rio;

    public KiaConveyor()
    {
        _rio = new Kia();
    }

    public void BuildWheels()
    {
        var wheel = new Wheel("Red", 15);
        _rio.Wheels = new List<Wheel> { wheel.Clone, wheel.Clone, wheel.Clone, wheel.Clone };
    }

    public void SetName(string kiaName)
    {
        _rio.Name = kiaName;
    }

    public Kia GetCar()
    {
        return _rio;
    }
}

class RenoConveyor : IConveyor<Reno>
{
    private Reno _reno;

    public RenoConveyor()
    {
        _reno = new Reno();
    }

    public void BuildWheels()
    {
        var wheel = new Wheel("Blue", 25);
        _reno.Wheels = new List<Wheel> { wheel.Clone, wheel.Clone, wheel.Clone, wheel.Clone };
    }

    public void SetName(string kiaName)
    {
        _reno.Name = kiaName;
    }

    public Reno GetCar()
    {
        return _reno;
    }
}