using PerqAddingProject.BaseClasses;
using PerqAddingProject.Perqs;

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
