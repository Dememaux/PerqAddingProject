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

        int baseClassWeight = 2;
        int secondaryClassWeight = 1;

        int numberOfPerqsToChooseFromOnLevelUp = 3;
        int numberOfPerqsToChooseFromOnLevelDown = 3;


        private Dictionary<CharacterClass, PerqPool> ClassDictionary
            = new Dictionary<CharacterClass, PerqPool>();

        #endregion

        #region Methods

        public void LevelUp(Character character)
        {
            IncreaseCharacterLevel(character);

            List<IPerq> perqsForSelection = new List<IPerq>();

            GetMainClassPerqs(perqsForSelection, character);

            GetSecondaryClassPerqs(perqsForSelection, character);

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

        private void GetMainClassPerqs(List<IPerq> perqsAvailable, Character character)
        {
            perqsAvailable.AddRange(GetWeightedPerqsFromPool(GetPoolByClass(character.MainClass),
                baseClassWeight));
        }

        private void GetSecondaryClassPerqs(List<IPerq> perqsAvailable, Character character)
        {
            foreach (CharacterClass characterClass in character.SecondaryClass)
            {
                perqsAvailable.AddRange(GetWeightedPerqsFromPool(GetPoolByClass(characterClass),
                    secondaryClassWeight));
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

        private PerqPool GetPoolByClass(CharacterClass characterClass)
        {
            return ClassDictionary[characterClass];
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
            ClassDictionary.Add(CharacterClass.Healthy, new HealthPool());
            ClassDictionary.Add(CharacterClass.Growing, new DamageOnAttackPool());
            ClassDictionary.Add(CharacterClass.Dangerous, new DamagePool());
        }

        #endregion
    }
}
