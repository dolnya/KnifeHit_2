using System.Collections;
using System.Collections.Generic;
using SDA.Generation;
using UnityEngine;

namespace SDA.CoreGameplay
{
    public class KnifeThrow : MonoBehaviour
    {
        private Knife knifeToThrow;

       public void SetKnife(Knife newKnife)
        {
            this.knifeToThrow = newKnife; 

        }

        public void Throw()
        {
            if (knifeToThrow != null)
            {

                knifeToThrow.ThrowKnife(knifeToThrow);
                knifeToThrow=null; 
            }
            }


        }


}