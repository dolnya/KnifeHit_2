using SDA.CoreGameplay;
using SDA.Generation;
using SDA.Input;
using UnityEngine;
using SDA.UI;
using UnityEngine.Events;
using System;

namespace SDA.Architecture
{
    public class SettingsState : BaseState
    {
        private SettingsView settingsView;
        private UnityAction transitionToMenuState;

        public SettingsState(UnityAction transitionToMenuState, SettingsView settingsView)
        {
            this.settingsView = settingsView;
            this.transitionToMenuState = transitionToMenuState;
        }
        public override void InitState()
        {
            Debug.Log("INIT MENU");

            if (settingsView != null)
                settingsView.ShowView();
            settingsView.BackSettingsButton.onClick.AddListener(transitionToMenuState);
        }
        public override void UpdateState()
        {
            
        }
        public override void DestroyState()
        {
            if (settingsView != null)
                settingsView.HideView();


            settingsView.BackSettingsButton.onClick.RemoveAllListeners();
        }
    }
}
