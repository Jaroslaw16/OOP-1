using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Interfaces.Data;

/// <summary>
/// Mammals collection.
/// </summary>
public interface IMammals
{
    #region Interface Members

    /// <summary>
    /// Animals collection.
    /// </summary>
    List<IDog> Dogs { get; set; }
    List<IWolf> Wolfs { get; set; }
    List<ISwan> Swans { get; set; }
    List<ICamel> Camels { get; set; }

    #endregion // Interface Members
}
