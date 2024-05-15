using PerqAddingProject.Perqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PerqAddingProject.BaseClasses
{
    public class PerqPool
    {
        #region Fields

        List<IPerq> perqList = new List<IPerq>();

        #endregion

        #region Properties

        public List<IPerq> PerqList
        {
            get { return perqList; }
        }

        #endregion

        #region Methods

        public List<IPerq> GetWeightedPerqs(int poolWeight)
        {
            if (poolWeight <= 1)
            {
                return perqList;
            }

            List <IPerq> temporaryList = new List<IPerq>();

            for (int i = 0; i < poolWeight; i++)
            {
                temporaryList.AddRange(perqList);
            }

            return temporaryList;
        }

        public void AddPerq(IPerq perq)
        {
            perqList.Add(perq);
        }

        #endregion

    }
}
