using DG.Tweening;
using SDA.CoreGameplay;
using SDA.Count;
using SDA.Generation;
using SDA.Input;
using SDA.UI;
using UnityEngine;
using UnityEngine.Events;




namespace SDA.Architecture
{
    public class GameState : BaseState
    {
        private GameView gameView;
        private InputSystem inputSystem;
        private LevelGenerator levelGenerator;
        private ShieldMovementController shieldMovementController;
        private KnifeThrow knifeThrow;
        private UnityAction transitionToEndState;
        private Score scoreclass;
        private StageController stageController;
        public GameState(GameView gameView, InputSystem inputSystem,
            LevelGenerator levelGenerator, ShieldMovementController
            shieldMovementController, KnifeThrow knifeThrow,
            UnityAction transitionToEndState, Score scoreclas, StageController stageController)
        {
            this.gameView = gameView;
            this.inputSystem = inputSystem;
            this.levelGenerator = levelGenerator;
            this.shieldMovementController = shieldMovementController;
            this.knifeThrow = knifeThrow;
            this.transitionToEndState = transitionToEndState;
            this.scoreclass = scoreclas;
            this.stageController = stageController;
            this.transitionToEndState = transitionToEndState;



        }

        public override void InitState()
        {
            if (gameView != null)
            {
                gameView.ShowView();
            }


            stageController.InitController();
            PrepareNewKnife();
            PrepareNewShield();
            inputSystem.AddListener(knifeThrow.Throw);
            //levelGenerator.SpawnKnife();
            inputSystem.AddListener(PrintDebug);


        }

        public override void UpdateState()
        {
            inputSystem.UpdateSystem();
            shieldMovementController.UpdateController();
        }

        public override void DestroyState()
        {
            if (gameView != null)
                gameView.HideView();

            //shieldMovementController.DisposeShield();
            inputSystem.RemoveAllListeners();
        }

        private void PrintDebug()
        {
            Debug.Log("BUTTON CLICKED");
        }
        private void PrepareNewKnife()
        {
            Debug.Log("Nowy nóŸ");
            scoreclass.UpdateScore();
            var newKnife = levelGenerator.SpawnKnife();

            newKnife.InitKnife(() => LoseGame(newKnife));
            knifeThrow.SetKnife(newKnife);



        }
        private void PrepareNewShield()
        {
            var nextStageType = stageController.NextStage();
            var newShield = levelGenerator.SpawnShield(nextStageType);

            UnityAction onShieldHit = gameView.DecreaseAmmo;
            onShieldHit += PrepareNewKnife;

            shieldMovementController.InitializeShield(newShield, onShieldHit, PrepareNewShield);
            Debug.Log("Nowa tarcza");

            gameView.SpawnAmmo(newShield.KnifesToWin);
            gameView.UpdateStage(stageController.CurrentStageModulo);

        }
        private void LoseGame(Knife lastKnife)
        {
            inputSystem.RemoveAllListeners();
            Debug.Log("Last Knife");
            lastKnife.Rigidbody2D.gravityScale = 1f;
            lastKnife.Rigidbody2D.freezeRotation = false;
            lastKnife.Rigidbody2D.velocity = Vector2.zero;
            lastKnife.Rigidbody2D.AddTorque(15f, ForceMode2D.Impulse);

            var loseSequence = DOTween.Sequence();
            loseSequence
                .SetDelay(1f)
                .OnComplete(() => DestroyKnifeAndProceed(lastKnife));
        }

        private void DestroyKnifeAndProceed(Knife lastKnife)
        {
            lastKnife.DestroyKnife();
            transitionToEndState.Invoke();
        }

    }
}