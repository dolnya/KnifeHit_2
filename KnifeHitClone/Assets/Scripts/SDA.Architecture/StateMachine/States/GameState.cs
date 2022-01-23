using System.Collections;
using System.Collections.Generic;
using SDA.CoreGameplay;
using SDA.Generation;
using SDA.Input;
using UnityEngine;
using SDA.UI;


namespace SDA.Architecture
{
    public class GameState : BaseState
    {
        private GameView gameView;
        private InputSystem inputSystem;
        private LevelGenerator levelGenerator;
        private ShieldMovementController shieldMovementController;
        private KnifeThrow knifeThrow;
        public GameState(GameView gameView, InputSystem inputSystem,
            LevelGenerator levelGenerator, ShieldMovementController shieldMovementController,KnifeThrow knifeThrow)
        {
            this.gameView = gameView;
            this.inputSystem = inputSystem;
            this.levelGenerator = levelGenerator;
            this.shieldMovementController = shieldMovementController;
            this.knifeThrow = knifeThrow;
        }

        public override void InitState()
        {
            if (gameView != null)
            {
                gameView.ShowView();
            }
            inputSystem.AddListener(knifeThrow.Throw);
            BaseShield startShield = levelGenerator.SpawnShield();
            shieldMovementController.InitializeShield(startShield);

            Knife knife = levelGenerator.SpawnKnife();
            knifeThrow.SetKnife(knife);


            //levelGenerator.SpawnKnife();
            //inputSystem.AddListener(PrintDebug);
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