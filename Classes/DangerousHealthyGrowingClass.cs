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
            SetMainClass(CharacterClass.Dangerous);
            AddSecondaryClass(CharacterClass.Healthy);
            AddSecondaryClass(CharacterClass.Growing);
        }
    }
}
