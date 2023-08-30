namespace SampleHierarchies.Interfaces.Data.Mammals;

/// <summary>
/// Interface depicting a wolf.
/// </summary>
public interface IWolf : IMammal
{
    #region Interface Members
    /// <summary>
    /// Ctor
    /// </summary>
    public string FurColor { get; set; }
    public int WeightInKilos { get; set; }
    public string Habitat { get; set; }

    #endregion // Interface Members
}
