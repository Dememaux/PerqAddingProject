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

        int numberOfPerqsToChooseFromOnLevelUP = 3;

        private Dictionary<CharacterClass, PerqPool> ClassDictionary
            = new Dictionary<CharacterClass, PerqPool>();

        #endregion

        #region Methods

        public void LevelUp(Character character)
        {
            character.Level++;

            Console.WriteLine();
            Console.Write("You level up! Current level: " + character.Level);
            Console.WriteLine();

            List<IPerq> perqsPossibleToGet = new List<IPerq>();

            perqsPossibleToGet.AddRange(GetWeightedPerqsFromPool(GetPoolByClass(character.MainClass),
                baseClassWeight));

            foreach (CharacterClass characterClass in character.SecondaryClass)
            {
                perqsPossibleToGet.AddRange(GetWeightedPerqsFromPool(GetPoolByClass(characterClass),
                    secondaryClassWeight));
            }

            Console.WriteLine("Choose a perq to get");
            Console.WriteLine();

            character.AddPerq(ShowPerqsToSelect(GetPerqsForSelection(perqsPossibleToGet,
                numberOfPerqsToChooseFromOnLevelUP)));
        }

        private List<IPerq> GetWeightedPerqsFromPool(PerqPool pool, int amount)
        {
            return pool.GetWeightedPerqs(amount);
        }

        private List<IPerq> GetPerqsForSelection(List<IPerq> perqsPossibleToGet,
            int numberOfPerqsForSelection)
        {
            List<IPerq> perqsForSelection = new List<IPerq>();

            while (perqsForSelection.Count < numberOfPerqsToChooseFromOnLevelUP)
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

        public void LevelDown(Character character)
        {
            character.Level--;

            Console.WriteLine();
            Console.Write("You level down! Current level: " + character.Level);
            Console.WriteLine();

            if (character == null) return;
            if (character.Perqs.Count == 0) return;

            List<IPerq> perqsPossibleToLose = character.Perqs;

            while (perqsPossibleToLose.Count > numberOfPerqsToChooseFromOnLevelUP)
            {
                Random random = new Random();
                int a = random.Next(0, perqsPossibleToLose.Count);

                perqsPossibleToLose.RemoveAt(a);
            }

            Console.WriteLine();
            Console.WriteLine("Choose a perq to lose");
            Console.WriteLine();

            character.RemovePerq(ShowPerqsToSelect(perqsPossibleToLose));
        }

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
