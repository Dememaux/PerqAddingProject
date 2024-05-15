using PerqAddingProject.BaseClasses;
using PerqAddingProject.Perqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerqAddingProject.CharacterClasses
{
    public class DamageOnAttackPool : PerqPool
    {
        public DamageOnAttackPool()
        {
            PerqList.Add(new AddDamageOnAttack(1));
            PerqList.Add(new AddDamageOnAttack(2));
            PerqList.Add(new AddDamageOnAttack(3));
        }
    }
}
