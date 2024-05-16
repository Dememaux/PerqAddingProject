using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerqAddingProject.Enums;

namespace PerqAddingProject.BaseClasses
{
    public class Character
    {
        #region Fields

        int level;

        int health;
        int damage;

        List<IPerq> characterPerqs = new List<IPerq>();

        CharacterClass mainClass;
        List<CharacterClass> secondaryClasses = new List<CharacterClass>();

        #endregion

        #region Properties

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public List<IPerq> Perqs
        {
            get { return characterPerqs; }
        }

        public CharacterClass MainClass
        {
            get { return mainClass; }
            set { mainClass = value; }
        }

        public List<CharacterClass> SecondaryClass
        {
            get { return secondaryClasses; }
            set { secondaryClasses = value; }
        }

        #endregion

        #region Methods

        #region Class Change Methods

        public void SetMainClass(CharacterClass mainClass)
        {
            MainClass = mainClass;
        }

        public void AddSecondaryClass(CharacterClass secondaryClass)
        {
            SecondaryClass.Add(secondaryClass);
        }

        public void RemoveSecondaryClass(CharacterClass secondaryClass)
        {
            SecondaryClass.Remove(secondaryClass);
        }

        public void ClearSecondaryClasses()
        {
            SecondaryClass.Clear();
        }

        #endregion

        #region Perq Change Methods

        public void AddPerq(IPerq perq)
        {
            characterPerqs.Add(perq);
            OnPerqAdd(perq);
        }

        public void RemovePerq(IPerq perq)
        {
            characterPerqs.Remove(perq);
            perq.OnRemoveEffect(this);
        }

        #endregion

        protected void OnPerqAdd(IPerq perq)
        {
            CheckTypeAndTriggerPerq(perq, PerqType.onAdd);
        }

        protected void CheckTypeAndTriggerPerq(IPerq perq, PerqType perqType)
        {
            if (perq.PerqType == perqType)
            {
                perq.Trigger(this);
            }
        }

        public void Attack()
        {
            Console.WriteLine("You attack and deal " + Damage
                + " damage!");

            if (characterPerqs.Count != 0)
            {
                foreach (IPerq perq in characterPerqs)
                {
                    CheckTypeAndTriggerPerq(perq, PerqType.onAttack);
                }
            }
        }

        #endregion
    }
}
