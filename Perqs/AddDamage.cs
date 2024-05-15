using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PerqAddingProject.BaseClasses;
using PerqAddingProject.Enums;

namespace PerqAddingProject.Perqs
{
    internal class AddDamage : IPerq
    {
        #region Fields

        PerqType perqType;

        int mainAmount;

        #endregion

        #region Properties

        public string Name
        {
            get { return " Add Damage "; }
        }

        public string Description
        {
            get { return "Gain " + mainAmount + " Damage"; }
        }

        public PerqType PerqType
        {
            get { return perqType; }
        }

        #endregion

        #region Methods

        public void Trigger(Character character)
        {
            character.Damage += mainAmount;
        }

        public void OnRemoveEffect(Character character)
        {
            character.Damage -= mainAmount;
        }

        #endregion

        #region Constructor

        public AddDamage(int mainAmount)
        {
            this.mainAmount = mainAmount;
            perqType = PerqType.onAdd;

        }

        #endregion
    }
}
