using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Camel class.
/// </summary>
public class Camel : MammalBase, ICamel
{
    #region Public Methods

    /// <inheritdoc/>
    public override void MakeSound()
    {
        Console.WriteLine("My name is: {0} and I am barking", Name);
    }

    /// <inheritdoc/>
    public override void Move()
    {
        Console.WriteLine("My name is: {0} and I am running", Name);
    }

    /// <inheritdoc/>
    public override void Display()
    {
        Console.WriteLine($"My name is: {Name}, my age is: {Age}, my color is: {Color}, my speed is {Speed}, my Diet is {Diet}");
    }

    /// <inheritdoc/>
    public override void Copy(IAnimal animal)
    {
        if (animal is ICamel ad)
        {
            base.Copy(animal);
            Name = ad.Name;
            Age = ad.Age;
            Color = ad.Color;
            Speed = ad.Speed;
            Diet = ad.Diet;
        }
    }

    #endregion // Public Methods

    #region Ctors And Properties

    /// <inheritdoc/>
    public string Color { get; set; }
    public int Speed { get; set; }
    public string Diet { get; set; }


    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="age">Age</param>
    /// <param name="color">Color</param>
    /// <param name="speed">Speed</param>
    /// <param name="diet">Diet</param>
    public Camel(string name, int age, string color, int speed, string diet)
    {
        Name = name;
        Age = age;
        Color = color;
        Speed = speed;
        Diet = diet;
    }

    #endregion // Ctors And Properties
}
