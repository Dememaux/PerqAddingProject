using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerqAddingProject.BaseClasses;
using PerqAddingProject.Enums;

namespace PerqAddingProject.Perqs
{
    public class AddHealth : IPerq
    {
        #region Fields

        PerqType perqType;

        int mainAmount;

        #endregion

        #region Properties

        public string Name
        {
            get { return " Add Health "; }
        }

        public string Description
        {
            get { return " Gain " + mainAmount + " Health "; }
        }

        public PerqType PerqType
        {
            get { return perqType; }
        }

        #endregion

        #region Methods

        public void Trigger(Character character)
        {
            character.Health += mainAmount;
        }

        public void OnRemoveEffect(Character character)
        {
            character.Health -= mainAmount;
        }

        #endregion

        #region Constructor

        public AddHealth(int mainAmount)
        {
            this.mainAmount = mainAmount;
            perqType = PerqType.onAdd;
        }

        #endregion
    }
}
