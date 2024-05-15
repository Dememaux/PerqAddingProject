using PerqAddingProject.BaseClasses;
using PerqAddingProject.Perqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerqAddingProject.CharacterClasses
{
    public class DamagePool : PerqPool
    {
        public DamagePool()
        {
            PerqList.Add(new AddDamage(1));
            PerqList.Add(new AddDamage(2));
            PerqList.Add(new AddDamage(3));
        }
    }
}
