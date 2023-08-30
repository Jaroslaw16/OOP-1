using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using System.Data;

namespace SampleHierarchies.Gui;

/// <summary>
/// Settings screen.
/// </summary>
public sealed class SettingsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>

    private ISettingsService _settingsService;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="animalsScreen">Animals screen</param>
    public SettingsScreen(
        ISettingsService settingsService)
    {
        _settingsService = settingsService;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            _settingsService.UpdateColor(ScreensEnum.SettingsScreen);
            Console.WriteLine();
            Console.WriteLine("Select display to edit color");
            Console.WriteLine("1. Main Screen");
            Console.WriteLine("2. Animals Screen");
            Console.WriteLine("3. Mammals Screen");
            Console.WriteLine("4. Dogs Screen");
            Console.WriteLine("5. Wolfs Screen");
            Console.WriteLine("6. Swans Screen");
            Console.WriteLine("7. Camels Screen");
            Console.WriteLine("8. Settings Screen");
            Console.WriteLine();
            Console.Write("Please enter your choice: ");

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }
                int choice = int.Parse(choiceAsString);
                switch (choice)
                {
                    case > 0 and < 9:
                        EditConsoleColor(choice);
                        break;

                    case 0:
                        Console.WriteLine("Goodbye.");
                        return;
                }
            }
            catch
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }

    #endregion // Public Methods

    #region Private Methods

    private void EditConsoleColor(int choice)
    {
        try
        {
            Console.Write("Write color: ");
            string? colorAsString = Console.ReadLine();
            if (colorAsString is null)
            {
                throw new ArgumentNullException(nameof(colorAsString));
            }
            ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorAsString);
            _settingsService.EditColor((ScreensEnum)choice-1, color);
        }
        catch
        {
            throw;
        }
  
    }

    #endregion // Private Methods
}