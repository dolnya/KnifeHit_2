using SDA.Generation;
using UnityEngine.Events;

namespace SDA.CoreGameplay
{
    public class ShieldMovementController
    {
        private BaseShield currentlyActiveShield;

        public void InitializeShield(BaseShield newShield , UnityAction callback)
        {
            //destroy old shield
            if (currentlyActiveShield != null)
                currentlyActiveShield.Dispose();


            currentlyActiveShield = newShield;
            currentlyActiveShield.Initialize(callback);
        }

        public void UpdateController()
        {
            if(currentlyActiveShield != null)
                currentlyActiveShield.Rotate();
        }
    }
}