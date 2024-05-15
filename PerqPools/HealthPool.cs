using PerqAddingProject.BaseClasses;
using PerqAddingProject.Perqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerqAddingProject.CharacterClasses
{
    public class HealthPool : PerqPool
    {
        public HealthPool()
        {
            PerqList.Add(new AddHealth(1));
            PerqList.Add(new AddHealth(2));
            PerqList.Add(new AddHealth(3));
        }
    }
}
