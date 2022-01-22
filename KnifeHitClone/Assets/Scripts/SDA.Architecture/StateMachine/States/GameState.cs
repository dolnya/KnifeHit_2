using System.Collections;
using System.Collections.Generic;
using SDA.CoreGameplay;
using SDA.Input;
using UnityEngine;
using SDA.UI;
using SDA.Generation;

namespace SDA.Architecture
{
    public class GameState : BaseState
    {
        private GameView gameView;
        private InputSystem inputSystem;
        private LevelGenerator levelGenerator;
        private ShieldMovementController shieldMovementController;

        public GameState(GameView gameView, InputSystem inputSystem,
            LevelGenerator levelGenerator, ShieldMovementController shieldMovementController)
        {
            this.gameView = gameView;
            this.inputSystem = inputSystem;
            this.levelGenerator = levelGenerator;
            this.shieldMovementController = shieldMovementController;
        }

        public override void InitState()
        {
            if(gameView!=null)
                gameView.ShowView();
            
            BaseShield startShield = levelGenerator.SpawnShield();
            shieldMovementController.InitializeShield(startShield);
            
            levelGenerator.SpawnKnife();
            inputSystem.AddListener(PrintDebug);
        }

        public override void UpdateState()
        {
            inputSystem.UpdateSystem();
            shieldMovementController.UpdateController();
        }

        public override void DestroyState()
        {
            if(gameView!=null)
                gameView.HideView();
            
            inputSystem.RemoveAllListeners();
        }

        private void PrintDebug()
        {
            Debug.Log("BUTTON CLICKED");
        }
    }
}