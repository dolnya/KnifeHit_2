using SDA.UI;
using UnityEngine;
using UnityEngine.Events;

namespace SDA.Architecture
{
    public class MenuState : BaseState
    {
        private MenuView menuView;
        private UnityAction transitionToGameState;
        private UnityAction settingsStateTransition;
        private UnityAction transitionToShopState;
        public MenuState(UnityAction transitionToGameState,
            UnityAction settingsStateTransition, UnityAction transitionToShopState, MenuView menuView)
        {
            this.menuView = menuView;
            this.transitionToGameState = transitionToGameState;
            this.settingsStateTransition = settingsStateTransition;
            this.transitionToShopState = transitionToShopState; ;
        }

        public override void InitState()
        {
            Debug.Log("INIT MENU");

            if (menuView != null)
                menuView.ShowView();

            menuView.PlayButton.onClick.AddListener(transitionToGameState);
            menuView.SettingsButton.onClick.AddListener(settingsStateTransition);
            menuView.ShopButton.onClick.AddListener(transitionToShopState);
        }

        public override void UpdateState()
        {

        }

        public override void DestroyState()
        {
            if (menuView != null)
                menuView.HideView();


            menuView.PlayButton.onClick.RemoveAllListeners();
            menuView.SettingsButton.onClick.RemoveAllListeners();
            menuView.ShopButton.onClick.RemoveAllListeners();
        }
    }
}