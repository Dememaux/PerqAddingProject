using PerqAddingProject.BaseClasses;
using PerqAddingProject.Perqs;

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
