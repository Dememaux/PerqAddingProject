using PerqAddingProject.BaseClasses;
using PerqAddingProject.Perqs;

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
