using System.Diagnostics;
using PatternsLab.Problems.Builder;
using PatternsLab.Problems.Prototype;
using PatternsLab.Problems.Singleton;

Console.WriteLine("=== SINGLETON: BEFORE ===\n");

var db = new DatabaseService();
var ui = new UiService();

Console.WriteLine();

db.Config.Theme = "Dark";
Console.WriteLine("Admin changed theme to Dark.");

ui.Render();

Console.WriteLine($"\nSame config object? {ReferenceEquals(db.Config, ui.Config)}");
Console.WriteLine($"Times config was loaded from disk: {AppConfig.LoadCount}");


Console.WriteLine("\n=== PROTOTYPE: AFTER ===\n");

var sw = Stopwatch.StartNew();

var registry = new EnemyRegistry();

// Register the prototypes
registry.Register("orc", new Orc());
registry.Register("elf", new Elf());

var army = new List<Enemy>();

for (int i = 1; i <= 5; i++)
{
    Enemy orc = registry.Create("orc");
    orc.Name = $"Orc-{i}";
    army.Add(orc);
}

sw.Stop();

Console.WriteLine(
    $"Created 5 orcs by cloning in {sw.ElapsedMilliseconds} ms"
);



Enemy original = registry.Create("orc");
original.Name = "Boss Orc";

Enemy copy = original.Clone();

Console.WriteLine($"\nOriginal model id: {original.ModelId}");
Console.WriteLine($"Copy model id:     {copy.ModelId}");



copy.Weapon.Damage = 999;

Console.WriteLine("\nChanged COPY weapon damage to 999.");
Console.WriteLine($"Original weapon damage: {original.Weapon.Damage}");



copy.Abilities.Add("Fire Breath");

Console.WriteLine($"Original abilities: {string.Join(", ", original.Abilities)}");
Console.WriteLine($"Copy abilities:     {string.Join(", ", copy.Abilities)}");