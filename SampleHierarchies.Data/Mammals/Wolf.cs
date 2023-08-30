using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Wolf class.
/// </summary>
public class Wolf : MammalBase, IWolf
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
        Console.WriteLine($"My name is: {Name}, my age is: {Age}, my furcolor is {FurColor}, my weight is {WeightInKilos}, my habitat is {Habitat} ");
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
    public string FurColor { get; set; }
    public int WeightInKilos { get; set; }
    public string Habitat { get; set; }

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="age">Age</param>
    /// <param name="furColor">FurColor</param>
    /// <param name="name">Name</param>
    /// <param name="weightInKilos">WeightInKilos</param>
    /// <param name="habitat">Habitat</param>
    public Wolf(string name, int age, string furColor, int weightInKilos, string habitat)
    {
        Name = name;
        Age = age;
        FurColor = furColor;
        WeightInKilos = weightInKilos;
        Habitat = habitat;
    }

    #endregion // Ctors And Properties
}
