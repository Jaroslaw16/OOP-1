using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Mammals collection.
/// </summary>
public class Mammals : IMammals
{
    #region IMammals Implementation

    /// <inheritdoc/>
    public List<IDog> Dogs { get; set; }
    public List<IWolf> Wolfs { get; set; }
    public List<ISwan> Swans { get; set; }

    public List<ICamel> Camels { get; set; }

    #endregion // IMammals Implementation

    #region Ctors

    /// <summary>
    /// Default ctor.
    /// </summary>
    public Mammals()
    {
        Dogs = new List<IDog>();
        Wolfs = new List<IWolf>();
        Swans = new List<ISwan>();
        Camels = new List<ICamel>();
    }

    #endregion // Ctors
}
