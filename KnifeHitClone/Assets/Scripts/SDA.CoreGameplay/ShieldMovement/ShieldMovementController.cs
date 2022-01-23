using SDA.Generation;
using UnityEngine.Events;

namespace SDA.CoreGameplay
{
    public class ShieldMovementController
    {
        private BaseShield currentlyActiveShield;

        

        public void InitializeShield(BaseShield newShield , 
            UnityAction onShieldHitCallback, UnityAction onWinCallback)
        {
            //destroy old shield
            if (currentlyActiveShield != null)
                currentlyActiveShield.Dispose();


            currentlyActiveShield = newShield;
            currentlyActiveShield.Initialize(onShieldHitCallback, onWinCallback);
        }

        public void UpdateController()
        {
            if(currentlyActiveShield != null)
                currentlyActiveShield.Rotate();
        }
    }
}