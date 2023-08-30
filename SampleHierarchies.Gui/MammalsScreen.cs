using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class MammalsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Animals screen.
    /// </summary>
    private DogsScreen _dogsScreen;
    private WolfScreen _wolfScreen;
    private SwansScreen _swanScreen;
    private CamelsScreen _camelsScreen;
    private ISettingsService _settingsService;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="dogsScreen">Dogs screen</param>
    public MammalsScreen(DogsScreen dogsScreen, WolfScreen wolfScreen, SwansScreen swanScreen, ISettingsService settingsService, CamelsScreen camelsScreen)
    {
        _settingsService = settingsService;
        _dogsScreen = dogsScreen;
        _wolfScreen = wolfScreen;
        _swanScreen = swanScreen;
        _camelsScreen = camelsScreen;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            _settingsService.UpdateColor(ScreensEnum.MammalsScreen);
            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Dogs");
            Console.WriteLine("2. Wolfs");
            Console.WriteLine("3. Swans");
            Console.WriteLine("4. Camel");
            Console.Write("Please enter your choice: ");

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                MammalsScreenChoices choice = (MammalsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MammalsScreenChoices.Dogs:
                        _dogsScreen.Show(); break;
                    case MammalsScreenChoices.Wolfs:
                        _wolfScreen.Show(); break;
                    case MammalsScreenChoices.Swans:
                        _swanScreen.Show(); break;
                    case MammalsScreenChoices.Camels:
                        _camelsScreen.Show(); break;
                    case MammalsScreenChoices.Exit:
                        Console.WriteLine("Going back to parent menu.");
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
}
