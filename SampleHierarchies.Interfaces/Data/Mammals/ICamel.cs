namespace SampleHierarchies.Interfaces.Data.Mammals;

/// <summary>
/// Interface depicting a Camel.
/// </summary>
public interface ICamel : IMammal
{
    #region Interface Members
    /// <summary>
    /// Ctor
    /// </summary>
    public string Color { get; set; }
    public int Speed { get; set; }
    public string Diet { get; set; }

    #endregion // Interface Members
}
