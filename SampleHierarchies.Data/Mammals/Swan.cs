using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Swan class.
/// </summary>
public class Swan : MammalBase, ISwan
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
        Console.WriteLine($"My name is: {Name}, my age is: {Age}, my color is: {Color}, my Wingspan is {Wingspan}, my Habitat is {Habitat}");
    }

    /// <inheritdoc/>
    public override void Copy(IAnimal animal)
    {
        if (animal is IDog ad)
        {
            base.Copy(animal);
            Name = ad.Name;
            Age = ad.Age;
        }
    }

    #endregion // Public Methods

    #region Ctors And Properties

    /// <inheritdoc/>
    public string Color { get; set; }
    public int Wingspan { get; set; }
    public string Habitat { get; set; }

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="age">Age</param>
    /// <param name="color">Color</param>
    /// <param name="wingspan">Wingspan</param>
    /// <param name="habitat">Habitat</param>
    public Swan(string name, int age, string color, int wingspan, string habitat)
    {
        Name = name;
        Age = age;
        Color = color;
        Wingspan = wingspan;
        Habitat = habitat;
    }

    #endregion // Ctors And Properties
}
