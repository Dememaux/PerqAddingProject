using PerqAddingProject.Enums;
using PerqAddingProject.Perqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerqAddingProject.BaseClasses
{
    public interface IPerq
    {
        #region Properties

        public string Name
        {
            get { return "ERROR: Perq Interface"; }
        }

        public string Description
        {
            get { return "ERROR: Perq Interface"; }
        }

        public PerqType PerqType
        {
            get { return PerqType.none; }
        }

        #endregion

        #region Methods

        public virtual void Trigger(Character character)
        {

        }

        public virtual void OnRemoveEffect(Character character)
        {

        }

        #endregion
    }
}
