using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;

namespace SampleHierarchies.Interfaces.Services;

public interface ISettingsService
{
    #region Interface Members

    /// <summary>
    /// Read settings.
    /// </summary>
    /// <param name="jsonPath">Json path</param>
    /// <returns></returns>
    public ISettings? Read(string jsonPath);

    /// <summary>
    /// Write settings.
    /// </summary>
    /// <param name="settings">Settings to written</param>
    /// <param name="jsonPath">Json path</param>
    public void Write(ISettings settings, string jsonPath);

    public void UpdateColor(ScreensEnum screenEnum);
    public void EditColor(ScreensEnum screensEnum, ConsoleColor consoleColor);

    #endregion // Interface Members
}
