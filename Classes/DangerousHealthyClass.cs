using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerqAddingProject.BaseClasses;
using PerqAddingProject.Enums;

namespace PerqAddingProject.Characters
{
    public class DangerousHealthyClass : Character
    {
        public DangerousHealthyClass()
        {
            SetMainClass(CharacterClass.Healthy);
            AddSecondaryClass(CharacterClass.Dangerous);
        }
    }
}
