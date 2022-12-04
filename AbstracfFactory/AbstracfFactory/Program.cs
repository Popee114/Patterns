
var Pasha = new Person(Console.ReadLine());
Pasha.GetInfoAboutBurger();
Pasha.GetInfoAboutDrink();

Console.ReadKey();

abstract class KFC
{
    abstract public IBurger GimmeBurger();
    abstract public IFolkDrink GimmeDrink();
}

class KFCRussia : KFC
{
    public override IBurger GimmeBurger()
    {
        return new BurgerRussia
        {
            Name = "Чизбургер",
            Description = "Про100 Чизбургер"
        };
    }

    public override IFolkDrink GimmeDrink()
    {
        return new Kissel
        {
            Name = "Кисель",
            Description = "Супержижа из желатина"
        };
    }
}

class KFCIndia : KFC
{
    public override IBurger GimmeBurger()
    {
        return new BurgerIndia
        {
            Name = "КарриЧиз",
            Description = "Чизбургер с карри"
        };
    }

    public override IFolkDrink GimmeDrink()
    {
        return new Tea
        {
            Name = "Чай с перцем",
            Description = "Чай из чайной розы с розовым перцем"
        };
    }
}

interface IBurger
{
    public string Name { get; set; }

    public string Description { get; set; }
}

interface IFolkDrink
{
    public string Name { get; set; }

    public string Description { get; set; }
}

class BurgerIndia : IBurger
{
    public string Name { get; set; }
    public string Description { get; set; }
}

class BurgerRussia : IBurger
{
    public string Name { get; set; }
    public string Description { get; set; }
}

class Kissel : IFolkDrink
{
    public string Name { get; set; }
    public string Description { get; set; }
}

class Tea : IFolkDrink
{
    public string Name { get; set; }
    public string Description { get; set; }
}

class Person
{
    private KFC _someKFC;
    private IBurger _burger;
    private IFolkDrink _folkDrink;

    public Person(string country)
    {
        _someKFC = GetKFC(country);
        _burger = _someKFC.GimmeBurger();
        _folkDrink = _someKFC.GimmeDrink();
    }

    public void GetInfoAboutBurger()
    {
        Console.WriteLine($"Название бургера: {_burger.Name}");
        Console.WriteLine($"Описание бургера: {_burger.Description}");
    }

    public void GetInfoAboutDrink()
    {
        Console.WriteLine($"Название напитка: {_folkDrink.Name}");
        Console.WriteLine($"Описание напитка: {_folkDrink.Description}");
    }

    KFC GetKFC(string country) => country switch
    {
        "Russia" => new KFCRussia(),
        "India" => new KFCIndia(),
        _ => null
    };
}

abstract class AbstractFactory
{
    public abstract AbstractProductA CreateProductA();
}
class ConcreteFactory1 : AbstractFactory
{
    public override AbstractProductA CreateProductA()
    {
        return new ProductA1();
    }
}
class ConcreteFactory2 : AbstractFactory
{
    public override AbstractProductA CreateProductA()
    {
        return new ProductA2();
    }
}

abstract class AbstractProductA
{ }

class ProductA1 : AbstractProductA
{ }

class ProductA2 : AbstractProductA
{ }

class Client
{
    private AbstractProductA abstractProductA;

    public Client(AbstractFactory factory)
    {
        abstractProductA = factory.CreateProductA();
    }
    public void Run()
    { }
}