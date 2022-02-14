using SDA.Generation;
using SDA.UI;
using UnityEngine;
using UnityEngine.Events;

namespace SDA.Architecture
{
    public class EndState : BaseState
    {
        private EndView endView;
        private StageController stageController;
        private UnityAction transitionToMenuState;
        private UnityAction transitionToGameState;

        public EndState(UnityAction transitionToMenuState, EndView endView,
            UnityAction transitionToGameState, StageController stageController)
        {
            this.endView = endView;
            this.transitionToMenuState = transitionToMenuState;
            this.stageController = stageController;
            this.transitionToGameState = transitionToGameState;
        }

        public override void InitState()
        {
            Debug.Log("INIT shop");

            if (endView != null)
                endView.ShowView();
            endView.RestartButton.onClick.AddListener(transitionToMenuState);
            endView.MenuButton.onClick.AddListener(transitionToGameState);
            //endView.UpdatePointsAndStage(Score.CurrentPoints, stageController.CurrentStage);

        }
        public override void UpdateState()
        {

        }
        public override void DestroyState()
        {
            endView.RestartButton.onClick.RemoveAllListeners();
            endView.MenuButton.onClick.RemoveAllListeners();

            if (endView != null)
                endView.HideView();


            endView.RestartButton.onClick.RemoveAllListeners();
        }

    }
}
