using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
