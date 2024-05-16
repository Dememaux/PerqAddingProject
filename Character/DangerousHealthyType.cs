using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerqAddingProject.BaseClasses;
using PerqAddingProject.Enums;

namespace PerqAddingProject.Characters
{
    public class DangerousHealthyType : Character
    {
        public DangerousHealthyType()
        {
            SetMainType(CharacterType.Healthy);
            AddSecondaryType(CharacterType.Dangerous);
        }
    }
}
