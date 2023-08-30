namespace SampleHierarchies.Interfaces.Data.Mammals;

/// <summary>
/// Interface depicting a Swan.
/// </summary>
public interface ISwan : IMammal
{
    #region Interface Members
    /// <summary>
    /// Ctor
    /// </summary>
    public string Color { get; set; }
    public int Wingspan { get; set; }
    public string Habitat { get; set; }

    #endregion // Interface Members
}
