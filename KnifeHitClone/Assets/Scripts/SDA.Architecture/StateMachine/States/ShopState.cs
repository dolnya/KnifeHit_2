using SDA.UI;
using UnityEngine;
using UnityEngine.Events;
namespace SDA.Architecture
{
    public class ShopState : BaseState
    {
        private ShopView shopView;
        private UnityAction transitionToMenuState;

        public ShopState(UnityAction transitionToMenuState, ShopView shopView)
        {
            this.shopView = shopView;
            this.transitionToMenuState = transitionToMenuState;
        }

        public override void InitState()
        {
            Debug.Log("INIT shop");

            if (shopView != null)
                shopView.ShowView();
            shopView.BackShopButton.onClick.AddListener(transitionToMenuState);
        }
        public override void UpdateState()
        {

        }
        public override void DestroyState()
        {
            if (shopView != null)
                shopView.HideView();


            shopView.BackShopButton.onClick.RemoveAllListeners();
        }

    }
}
