using PerqAddingProject.BaseClasses;
using PerqAddingProject.Enums;

namespace PerqAddingProject.Perqs
{
    public class AddDamageOnAttack : IPerq
    {
        #region Fields

        PerqType perqType;

        int mainAmount;

        int totalDamageGained;

        #endregion

        #region Properties

        public string Name
        {
            get { return " Damage On Attack "; }
        }

        public string Description
        {
            get { return " Gain " + mainAmount + " Damage when you attack "; }
        }

        public PerqType PerqType
        {
            get { return perqType; }
        }

        #endregion

        #region Methods

        public void Trigger(Character character)
        {
            Console.WriteLine(" Damage increased! ");
            character.Damage += mainAmount;
            totalDamageGained += mainAmount;
        }

        public virtual void OnRemoveEffect(Character character)
        {
            totalDamageGained -= totalDamageGained;
        }

        #endregion

        #region Constructor

        public AddDamageOnAttack(int mainAmount)
        {
            this.mainAmount = mainAmount;
            perqType = PerqType.onAttack;
        }

        #endregion
    }
}
