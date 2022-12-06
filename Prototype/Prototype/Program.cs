
var cell1 = new SomeCell1("Lol");
cell1.GetInfo();

var cell2 = cell1.CreateCopy();
cell2.GetInfo();

var cell3 = cell1.CreateCopyViaMemberwiseClone();
cell3.GetInfo();

Console.ReadKey();

class SomeName
{
    public string Name { get; set; }
    public Guid Id { get; set; }
}

interface ISomeCell
{
    public ISomeCell CreateCopy();

    public ISomeCell CreateCopyViaMemberwiseClone();

    public void GetInfo();
}

class SomeCell1 : ISomeCell
{
    private SomeName SomeName;

    public SomeCell1(string name)
    {
        SomeName = new SomeName { Name = name, Id = Guid.NewGuid() };
    }

    public ISomeCell CreateCopy()
    {
        return new SomeCell1(SomeName.Name);
    }

    public ISomeCell CreateCopyViaMemberwiseClone()
    {
        return this.MemberwiseClone() as ISomeCell;
    }

    public void GetInfo()
    {
        Console.WriteLine($"{SomeName.Name}\n{SomeName.Id}\n");
    }
}
