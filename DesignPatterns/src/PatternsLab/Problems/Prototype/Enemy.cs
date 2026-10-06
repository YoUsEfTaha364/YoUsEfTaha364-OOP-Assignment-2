namespace PatternsLab.Problems.Prototype;

public class Weapon
{
    public string Name { get; set; }
    public int Damage { get; set; }
}

public abstract class Enemy
{
    private string _modelData;

    public string Name { get; set; }
    public int Health { get; set; }
    public Weapon Weapon { get; set; }
    public List<string> Abilities { get; set; } = new();
    public string ModelId => _modelData;

    public abstract Enemy Clone();


 protected Enemy()
    {
      
            Console.WriteLine("   ...loading 3D model (slow)...");
            Thread.Sleep(500);

            _modelData = "MODEL_" + Guid.NewGuid().ToString("N")[..6];
    
    }



    protected void CopyData(Enemy copy)
    {
         copy._modelData=this._modelData;
         copy.Name = this.Name;
        copy.Health = this.Health;

        copy.Weapon = new Weapon
        {
            Name = this.Weapon.Name,
            Damage = this.Weapon.Damage
        };

        copy.Abilities = new List<string>(this.Abilities);
    }
}

public class Orc : Enemy
{
    public Orc() : base()
    {
        Name = "Orc";
        Health = 100;
        Weapon = new Weapon { Name = "Axe", Damage = 25 };
        Abilities.Add("Rage");
    }

    public  override Enemy Clone()
    {
        Orc copy=new Orc();

        CopyData(copy);

        return copy;
    }
    
}

public class Elf : Enemy
{
    public Elf()
    {
        Name = "Elf";
        Health = 70;
        Weapon = new Weapon { Name = "Bow", Damage = 18 };
        Abilities.Add("Stealth");
    }

    

      public override Enemy Clone()
    {
        Elf copy=new Elf();

        CopyData(copy);

        return copy;
    }
}



// public static class EnemyCopyHelper
// {
//     public static Enemy CopyEnemy(Enemy e)
//     {
//         Enemy copy;

//         if (e is Orc)
//             copy = new Orc();
//         else if (e is Elf)
//             copy = new Elf();
//         else
//             throw new NotSupportedException("Unknown enemy type");

//         copy.Name = e.Name;
//         copy.Health = e.Health;

//         copy.Weapon = new Weapon
//         {
//             Name = e.Weapon.Name,
//             Damage = e.Weapon.Damage
//         };

//         copy.Abilities = new List<string>(e.Abilities);

//         return copy;
//     }
// }
public class EnemyRegistry
{
    private readonly Dictionary<string, Enemy> _prototypes = new();

    public void Register(string name, Enemy prototype)
    {
        _prototypes[name] = prototype;
    }

    public Enemy Create(string name)
    {
        if (!_prototypes.ContainsKey(name))
            throw new KeyNotFoundException($"Prototype '{name}' not found.");

        return _prototypes[name].Clone();
    }
}