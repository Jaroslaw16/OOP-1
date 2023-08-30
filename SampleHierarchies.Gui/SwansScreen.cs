using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui
{
    /// <summary>
    /// Swan's screen.
    /// </summary>
    public sealed class SwansScreen : Screen
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
        public SwansScreen(IDataService dataService, ISettingsService settingsService)
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
                _settingsService.UpdateColor(ScreensEnum.SwansScreen);
                Console.WriteLine();
                Console.WriteLine("Your available choices are:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. List all swans");
                Console.WriteLine("2. Create a new swan");
                Console.WriteLine("3. Delete existing swan");
                Console.WriteLine("4. Modify existing swan");
                Console.Write("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    SwanScreenChoices choice = (SwanScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case SwanScreenChoices.List:
                            ListSwan();
                            break;

                        case SwanScreenChoices.Create:
                            AddSwan();
                            break;

                        case SwanScreenChoices.Delete:
                            DeleteSwan();
                            break;

                        case SwanScreenChoices.Modify:
                            EditSwanMain();
                            break;

                        case SwanScreenChoices.Exit:
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
        /// List all swan's.
        /// </summary>
        private void ListSwan()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Swans is not null &&
                _dataService.Animals.Mammals.Swans.Count > 0)
            {
                Console.WriteLine("Here's a list of swan's:");
                int i = 1;
                foreach (Swan swan in _dataService.Animals.Mammals.Swans)
                {
                    Console.Write($"Swan number {i}, ");
                    swan.Display();
                    i++;
                }
            }
            else
            {
                Console.WriteLine("The list of swan's is empty.");
            }
        }

        /// <summary>
        /// Add a swan.
        /// </summary>
        private void AddSwan()
        {
            try
            {
                Swan swan = AddEditSwan();
                _dataService?.Animals?.Mammals?.Swans?.Add(swan);
                Console.WriteLine("Swan with name: {0} has been added to a list of swan's", swan.Name);
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Deletes a swan.
        /// </summary>
        private void DeleteSwan()
        {
            try
            {
                Console.Write("What is the name of the swan you want to delete? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Swan? swan = (Swan?)(_dataService?.Animals?.Mammals?.Swans
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (swan is not null)
                {
                    _dataService?.Animals?.Mammals?.Swans?.Remove(swan);
                    Console.WriteLine("Swan with name: {0} has been deleted from a list of Swans", swan.Name);
                }
                else
                {
                    Console.WriteLine("Swan not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Edits an existing swan after choice made.
        /// </summary>
        private void EditSwanMain()
        {
            try
            {
                Console.Write("What is the name of the swan you want to edit? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Swan? swan = (Swan?)(_dataService?.Animals?.Mammals?.Swans?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (swan is not null)
                {
                    Swan swanEdited = AddEditSwan();
                    swan.Copy(swanEdited);
                    Console.Write("Swan after edit:");
                    swan.Display();
                }
                else
                {
                    Console.WriteLine("Swan not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        /// <summary>
        /// Adds/edit specific swan.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Swan AddEditSwan()
        {
            Console.Write("What name of the swan? ");
            string? name = Console.ReadLine();
            Console.Write("What is the swan's age? ");
            string? ageAsString = Console.ReadLine();
            Console.Write("What is the swan's color? ");
            string? color = Console.ReadLine();
            Console.Write("What is the swan's wingspan? ");
            string? wingspanAsString = Console.ReadLine();
            Console.Write("What is the swan's habitat? ");
            string? habitat = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (color is null)
            {
                throw new ArgumentNullException(nameof(color));
            }
            if (wingspanAsString is null)
            {
                throw new ArgumentNullException(nameof(wingspanAsString));
            }
            if (habitat is null)
            {
                throw new ArgumentNullException(nameof(habitat));
            }
            int age = Int32.Parse(ageAsString);
            int wingspan = Int32.Parse(wingspanAsString);
            Swan swan = new Swan(name, age, color, wingspan, habitat);
            return swan;
        }

        #endregion // Private Methods
    }
}
