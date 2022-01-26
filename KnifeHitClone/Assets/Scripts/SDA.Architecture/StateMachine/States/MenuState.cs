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
        public MenuState(UnityAction transitionToGameState, UnityAction settingsStateTransition, MenuView menuView)
        {
            this.menuView = menuView;
            this.transitionToGameState = transitionToGameState;
            this.settingsStateTransition = settingsStateTransition;
        }

        public override void InitState()
        {
            Debug.Log("INIT MENU");
            
            if(menuView != null)
                menuView.ShowView();
            
            menuView.PlayButton.onClick.AddListener(transitionToGameState);
            menuView.SettingsButton.onClick.AddListener(settingsStateTransition);
        }

        public override void UpdateState()
        {
            
        }

        public override void DestroyState()
        {
            if (menuView != null) 
                menuView.HideView();


            menuView.PlayButton.onClick.RemoveAllListeners();
        }
    }
}