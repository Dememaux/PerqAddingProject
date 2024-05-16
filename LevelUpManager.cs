using PerqAddingProject.CharacterClasses;
using PerqAddingProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PerqAddingProject.BaseClasses
{
    public class LevelUpManager
    {
        #region Fields

        int mainTypeWeight = 2;
        int secondaryTypeWeight = 1;

        int numberOfPerqsToChooseFromOnLevelUp = 3;
        int numberOfPerqsToChooseFromOnLevelDown = 3;


        private Dictionary<CharacterType, PerqPool> TypeDictionary
            = new Dictionary<CharacterType, PerqPool>();

        #endregion

        #region Methods

        public void LevelUp(Character character)
        {
            IncreaseCharacterLevel(character);

            List<IPerq> perqsForSelection = new List<IPerq>();

            GetMainTypePerqs(perqsForSelection, character);

            GetSecondaryTypePerqs(perqsForSelection, character);

            AddPlayerSelectedPerq(perqsForSelection, character);

        }

        #region LevelUp methods

        private void IncreaseCharacterLevel(Character character)
        {
            character.Level++;

            Console.WriteLine();
            Console.Write("You level up! Current level: " + character.Level);
            Console.WriteLine();
        }

        private void GetMainTypePerqs(List<IPerq> perqsAvailable, Character character)
        {
            perqsAvailable.AddRange(GetWeightedPerqsFromPool(GetPoolByType(character.MainType),
                mainTypeWeight));
        }

        private void GetSecondaryTypePerqs(List<IPerq> perqsAvailable, Character character)
        {
            foreach (CharacterType characterType in character.SecondaryType)
            {
                perqsAvailable.AddRange(GetWeightedPerqsFromPool(GetPoolByType(characterType),
                    secondaryTypeWeight));
            }
        }

        private void AddPlayerSelectedPerq(List<IPerq> perqsAvailable, Character character)
        {
            Console.WriteLine("Choose a perq to get");
            Console.WriteLine();

            character.AddPerq(ShowPerqsToSelect(GetPerqsForSelection(perqsAvailable,
                numberOfPerqsToChooseFromOnLevelUp)));
        }

        private List<IPerq> GetWeightedPerqsFromPool(PerqPool pool, int amount)
        {
            return pool.GetWeightedPerqs(amount);
        }

        private List<IPerq> GetPerqsForSelection(List<IPerq> perqsPossibleToGet,
            int numberOfPerqsForSelection)
        {
            List<IPerq> perqsForSelection = new List<IPerq>();

            while (perqsForSelection.Count < numberOfPerqsToChooseFromOnLevelUp)
            {
                Random random = new Random();
                int a = random.Next(0, perqsPossibleToGet.Count());

                perqsForSelection.Add(perqsPossibleToGet[a]);
                perqsPossibleToGet.RemoveAt(a);
            }

            return perqsForSelection;
        }

        private PerqPool GetPoolByType(CharacterType characterType)
        {
            return TypeDictionary[characterType];
        }

        private IPerq ShowPerqsToSelect(List<IPerq> perqs)
        {
            foreach (IPerq perq in perqs)
            {
                Console.WriteLine(perqs.IndexOf(perq) + 1 + " " + perq.Name);
                Console.WriteLine(perq.Description);
                Console.WriteLine();
            }

            Console.WriteLine("Choose the perq and submit!");

            string a = " ";
            int b;

            a = Console.ReadLine();

            while (!int.TryParse(a, out b))
            {
                Console.WriteLine("Not a valid choice. Try again!");
                a = Console.ReadLine();
            }

            b = int.Parse(a);
            return perqs[b - 1];
        }

        #endregion

        public void LevelDown(Character character)
        {
            DecreaseCharacterLevel(character);

            if (character == null) return;
            if (character.Perqs.Count == 0) return;

            List<IPerq> perqsPossibleToLose = character.Perqs;

            GetPerqsPossibleToLose(perqsPossibleToLose, character);

            RemovePlayerSelectedPerq(perqsPossibleToLose, character);
        }

        #region LevelDown methods

        private void DecreaseCharacterLevel(Character character)
        {
            character.Level--;

            Console.WriteLine();
            Console.Write("You level down! Current level: " + character.Level);
            Console.WriteLine();
        }

        private void GetPerqsPossibleToLose(List<IPerq> perqsForSelection, Character character)
        {
            while (perqsForSelection.Count > numberOfPerqsToChooseFromOnLevelDown)
            {
                Random random = new Random();
                int a = random.Next(0, perqsForSelection.Count);

                perqsForSelection.RemoveAt(a);
            }
        }

        private void RemovePlayerSelectedPerq(List<IPerq> perqsForSelection, Character character)
        {
            Console.WriteLine();
            Console.WriteLine("Choose a perq to lose");
            Console.WriteLine();

            character.RemovePerq(ShowPerqsToSelect(perqsForSelection));
        }


        #endregion

        #endregion

        #region Constructor

        public LevelUpManager()
        {
            TypeDictionary.Add(CharacterType.Healthy, new HealthPool());
            TypeDictionary.Add(CharacterType.Growing, new DamageOnAttackPool());
            TypeDictionary.Add(CharacterType.Dangerous, new DamagePool());
        }

        #endregion
    }
}
