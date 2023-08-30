using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Wolf's screen.
/// </summary>
public sealed class WolfScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;
    private ISettingsService _settingsService;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    public WolfScreen(IDataService dataService, ISettingsService settingsService)
    {
        _dataService = dataService;
        _settingsService = settingsService;

    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            _settingsService.UpdateColor(ScreensEnum.WolfsScreen);
            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. List all wolfs");
            Console.WriteLine("2. Create a new wolf");
            Console.WriteLine("3. Delete existing wolf");
            Console.WriteLine("4. Modify existing wolf");
            Console.Write("Please enter your choice: ");

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                WolfScreenChoices choice = (WolfScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case WolfScreenChoices.List:
                        ListWolf();
                        break;

                    case WolfScreenChoices.Create:
                        AddWolf(); break;

                    case WolfScreenChoices.Delete:
                        DeleteWolf();
                        break;

                    case WolfScreenChoices.Modify:
                        EditWolfMain();
                        break;

                    case WolfScreenChoices.Exit:
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

    #region Private Methods

    /// <summary>
    /// List all wolf's.
    /// </summary>
    private void ListWolf()
    {
        Console.WriteLine();
        if (_dataService?.Animals?.Mammals?.Wolfs is not null &&
            _dataService.Animals.Mammals.Wolfs.Count > 0)
        {
            Console.WriteLine("Here's a list of wolfs:");
            int i = 1;
            foreach (Wolf wolf in _dataService.Animals.Mammals.Wolfs)
            {
                Console.Write($"Wolf number {i}, ");
                wolf.Display();
                i++;
            }
        }
        else
        {
            Console.WriteLine("The list of wolfs is empty.");
        }
    }

    /// <summary>
    /// Add a wolf.
    /// </summary>
    private void AddWolf()
    {
        try
        {
            Wolf wolf = AddEditWolf();
            _dataService?.Animals?.Mammals?.Wolfs?.Add(wolf);
            Console.WriteLine("Wolf with name: {0} has been added to a list of wolfs", wolf.Name);
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Deletes a wolf.
    /// </summary>
    private void DeleteWolf()
    {
        try
        {
            Console.Write("What is the name of the wolf you want to delete? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Wolf? wolf = (Wolf?)(_dataService?.Animals?.Mammals?.Wolfs
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (wolf is not null)
            {
                _dataService?.Animals?.Mammals?.Wolfs?.Remove(wolf);
                Console.WriteLine("Wolf with name: {0} has been deleted from a list of Wolfs", wolf.Name);
            }
            else
            {
                Console.WriteLine("Wolf not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Edits an existing wolf after choice made.
    /// </summary>
    private void EditWolfMain()
    {
        try
        {
            Console.Write("What is the name of the wolf you want to edit? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Wolf? wolf = (Wolf?)(_dataService?.Animals?.Mammals?.Wolfs?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (wolf is not null)
            {
                Wolf wolfEdited = AddEditWolf();
                wolf.Copy(wolfEdited);
                Console.Write("Wolf after edit:");
                wolf.Display();
            }
            else
            {
                Console.WriteLine("Wolf not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input. Try again.");
        }
    }

    /// <summary>
    /// Adds/edit specific wolf.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    private Wolf AddEditWolf()
    {
        Console.Write("What name of the wolf? ");
        string? name = Console.ReadLine();
        Console.Write("What is the wolf's age? ");
        string? ageAsString = Console.ReadLine();
        Console.Write("What is the wolf's fur color? ");
        string? furColor = Console.ReadLine();
        Console.Write("What is the wolf's weight in kilograms? ");
        string? kilogramsAsString = Console.ReadLine();
        Console.Write("What is the wolf's habitat? ");
        string? habitat = Console.ReadLine();

        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        if (ageAsString is null)
        {
            throw new ArgumentNullException(nameof(ageAsString));
        }
        if (furColor is null)
        {
            throw new ArgumentNullException(nameof(furColor));
        }
        if (kilogramsAsString is null)
        {
            throw new ArgumentNullException(nameof(kilogramsAsString));
        }
        if (habitat is null)
        {
            throw new ArgumentNullException(nameof(habitat));
        }
        int age = Int32.Parse(ageAsString);
        int kilgrams = Int32.Parse(kilogramsAsString);
        Wolf wolf = new Wolf(name, age, furColor, kilgrams, habitat);
        return wolf;
    }

    #endregion // Private Methods
}
