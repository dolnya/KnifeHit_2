using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDA.UI;
using UnityEngine.Events;
using System;
namespace SDA.Architecture
{
    public class EndState : BaseState
    {
        private EndView endView;
        private UnityAction transitionToMenuState;

        public EndState(UnityAction transitionToMenuState, EndView endView)
        {
            this.endView = endView;
            this.transitionToMenuState = transitionToMenuState;
        }

        public override void InitState()
        {
            Debug.Log("INIT shop");

            if (endView != null)
                endView.ShowView();
            endView.BackEndButton.onClick.AddListener(transitionToMenuState);
        }
        public override void UpdateState()
        {

        }
        public override void DestroyState()
        {
            if (endView != null)
                endView.HideView();


            endView.BackEndButton.onClick.RemoveAllListeners();
        }

    }
}
