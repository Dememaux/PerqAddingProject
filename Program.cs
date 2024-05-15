using PerqAddingProject.BaseClasses;
using PerqAddingProject.Characters;

namespace PerqAddingProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fight starts!");
            Console.WriteLine();

            LevelUpManager levelUpManager = new LevelUpManager();

            DangerousHealthyGrowingClass franek = new DangerousHealthyGrowingClass();

            franek.Damage = 3;
            franek.Health = 2;

            Console.WriteLine("Franek has " + franek.Damage + " attack");
            Console.WriteLine("Franek has " + franek.Health + " health");

            Console.WriteLine();
            Console.WriteLine("Franek attacks!");
            franek.Attack();
            Console.WriteLine();

            Console.WriteLine("Franek levels up!");
            levelUpManager.LevelUp(franek);

            Console.WriteLine("");
            Console.WriteLine("Franek has " + franek.Damage + " attack");
            Console.WriteLine("Franek has " + franek.Health + " health");

            Console.WriteLine();
            Console.WriteLine("Franek attacks!");
            franek.Attack();
            Console.WriteLine();

            Console.WriteLine("Franek has " + franek.Damage + " attack");
            Console.WriteLine("Franek has " + franek.Health + " health");

            Console.WriteLine();
            Console.WriteLine("Franek attacks!");
            franek.Attack();
            Console.WriteLine();

            Console.WriteLine("Franek levels up!");
            levelUpManager.LevelUp(franek);

            Console.WriteLine();
            Console.WriteLine("Franek attacks!");
            franek.Attack();
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Loses a level!");
            levelUpManager.LevelDown(franek);

            Console.WriteLine("Franek levels up!");
            levelUpManager.LevelUp(franek);

            Console.WriteLine("Franek levels up!");
            levelUpManager.LevelUp(franek);

            Console.WriteLine("Franek levels up!");
            levelUpManager.LevelUp(franek);

            Console.WriteLine("Franek levels up!");
            levelUpManager.LevelUp(franek);

            Console.WriteLine();
            Console.WriteLine("Franek attacks!");
            franek.Attack();
            Console.WriteLine();

        }
    }
}
