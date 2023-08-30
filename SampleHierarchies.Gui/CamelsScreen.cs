using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui
{
    /// <summary>
    /// Camel's screen.
    /// </summary>
    public sealed class CamelsScreen : Screen
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
        public CamelsScreen(IDataService dataService, ISettingsService settingsService)
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
                _settingsService.UpdateColor(ScreensEnum.CamelsScreen);
                Console.WriteLine();
                Console.WriteLine("Your available choices are:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. List all camels");
                Console.WriteLine("2. Create a new camel");
                Console.WriteLine("3. Delete existing camel");
                Console.WriteLine("4. Modify existing camel");
                Console.Write("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    CamelScreenChoices choice = (CamelScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case CamelScreenChoices.List:
                            ListCamel();
                            break;

                        case CamelScreenChoices.Create:
                            AddCamel();
                            break;

                        case CamelScreenChoices.Delete:
                            DeleteCamel();
                            break;

                        case CamelScreenChoices.Modify:
                            EditCamelMain();
                            break;

                        case CamelScreenChoices.Exit:
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
        /// List all camel's.
        /// </summary>
        private void ListCamel()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Camels is not null &&
                _dataService.Animals.Mammals.Camels.Count > 0)
            {
                Console.WriteLine("Here's a list of camels:");
                int i = 1;
                foreach (Camel camel in _dataService.Animals.Mammals.Camels)
                {
                    Console.Write($"Camel number {i}, ");
                    camel.Display();
                    i++;
                }
            }
            else
            {
                Console.WriteLine("The list of camels is empty.");
            }
        }

        /// <summary>
        /// Add a camel.
        /// </summary>
        private void AddCamel()
        {
            try
            {
                Camel camel = AddEditCamel();
                _dataService?.Animals?.Mammals?.Camels?.Add(camel);
                Console.WriteLine("Camel with name: {0} has been added to a list of camels", camel.Name);
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Deletes a camel.
        /// </summary>
        private void DeleteCamel()
        {
            try
            {
                Console.Write("What is the name of the camel you want to delete? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Camel? camel = (Camel?)(_dataService?.Animals?.Mammals?.Camels
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (camel is not null)
                {
                    _dataService?.Animals?.Mammals?.Camels?.Remove(camel);
                    Console.WriteLine("Camel with name: {0} has been deleted from a list of camels", camel.Name);
                }
                else
                {
                    Console.WriteLine("Camel not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Edits an existing camel after choice made.
        /// </summary>
        private void EditCamelMain()
        {
            try
            {
                Console.Write("What is the name of the camel you want to edit? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Camel? camel = (Camel?)(_dataService?.Animals?.Mammals?.Camels?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (camel is not null)
                {
                    Camel camelEdited = AddEditCamel();
                    camel.Copy(camelEdited);
                    Console.Write("Camel after edit:");
                    camel.Display();
                }
                else
                {
                    Console.WriteLine("Camel not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        /// <summary>
        /// Adds/edit specific camel.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Camel AddEditCamel()
        {
            Console.Write("What name of the camel? ");
            string? name = Console.ReadLine();
            Console.Write("What is the camel's age? ");
            string? ageAsString = Console.ReadLine();
            Console.Write("What is the camel's color? ");
            string? color = Console.ReadLine();
            Console.Write("What is the camel's speed? ");
            string? speedAsString = Console.ReadLine();
            Console.Write("What is the camel's diet? ");
            string? diet = Console.ReadLine();

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
            if (speedAsString is null)
            {
                throw new ArgumentNullException(nameof(speedAsString));
            }
            if (diet is null)
            {
                throw new ArgumentNullException(nameof(diet));
            }
            int age = Int32.Parse(ageAsString);
            int speed = Int32.Parse(speedAsString);
            Camel camel = new Camel(name, age, color, speed, diet);
            return camel;
        }

        #endregion // Private Methods
    }
}
