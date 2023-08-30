using Newtonsoft.Json;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using Newtonsoft;
using SampleHierarchies.Data;
using SampleHierarchies.Enums;
using System.Diagnostics;

namespace SampleHierarchies.Services;

/// <summary>
/// Settings service.
/// </summary>
public class SettingsService : ISettingsService
{
    #region ISettings Implementation

    /// <inheritdoc/>
    public ISettings? Read(string jsonPath)
    {
        try
        {
            if (jsonPath is null)
            {
                throw new ArgumentNullException(nameof(jsonPath));
            }
            string jsonSource = File.ReadAllText(jsonPath);
            var jsonContent = System.Text.Json.JsonSerializer.Deserialize<Settings>(jsonSource);
            if (jsonContent == null)
            {
                throw new ArgumentNullException(nameof(jsonContent));
            }
            return jsonContent;
        }
        catch
        {
            Console.WriteLine("Data reading was not successful.");
            return null;
        }
    }

    /// <inheritdoc/>
    public void Write(ISettings settings, string jsonPath)
    {
        try
        {
            if (jsonPath is null) throw new ArgumentNullException(nameof(jsonPath));
            File.WriteAllText(jsonPath, JsonConvert.SerializeObject(settings));
            Console.WriteLine("Data saving to: '{0}' was successful.", jsonPath);
        }
        catch
        {
            Console.WriteLine("Data saving was not successful.");
        }
    }
    // Used to update Console Color
    public void UpdateColor(ScreensEnum screenEnum)
    {
        try
        {
            Console.ForegroundColor = Read("Settings.json")?.ScreensColor[screenEnum] ?? ConsoleColor.White;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Data reading from json was not successful.");
            Debug.WriteLine(ex.Message.ToString());
            throw;
        }
    }
    // Used to edit and save json 
    public void EditColor(ScreensEnum screensEnum, ConsoleColor consoleColor)
    {
        var _settings = Read("Settings.json") ?? new Settings();
        _settings.ScreensColor[screensEnum] = consoleColor;
        Write(_settings, "Settings.json");
    }

    #endregion // ISettings Implementation
}