

(new Thread(() =>
{
    Computer comp = new Computer();
    comp.Launch();
    Console.WriteLine(comp.OS.Name);
})).Start();

Computer comp = new Computer();
// у нас не получится изменить ОС, так как объект уже создан    
comp.OS = OS.GetInstance();
Console.WriteLine(comp.OS.Name);


Console.ReadKey();

class OS
{
    private static readonly Lazy<OS> lazy =
        new Lazy<OS>(() => new OS());

    public string Name { get; private set; }

    private OS()
    {
        Name = Guid.NewGuid().ToString();
    }

    public static OS GetInstance()
    {
        return lazy.Value;
    }
}
class Computer
{
    public OS OS { get; set; }
    public void Launch()
    {
        OS = OS.GetInstance();
    }
}