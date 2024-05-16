using PerqAddingProject.BaseClasses;
using PerqAddingProject.Enums;

namespace PerqAddingProject.Characters
{
    public class DangerousHealthyGrowingClass : Character
    {
        public DangerousHealthyGrowingClass()
        {
            SetMainType(CharacterType.Dangerous);
            AddSecondaryType(CharacterType.Healthy);
            AddSecondaryType(CharacterType.Growing);
        }
    }
}
