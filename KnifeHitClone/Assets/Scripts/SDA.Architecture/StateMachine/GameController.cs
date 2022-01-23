using SDA.CoreGameplay;
using SDA.Generation;
using SDA.Input;
using SDA.UI;
using UnityEngine;
using UnityEngine.Events;

namespace SDA.Architecture
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private MenuView menuView;
        
        [SerializeField]
        private GameView gameView;

        [SerializeField] 
        private LevelGenerator levelGenerator;

        private InputSystem inputSystem;
        private ShieldMovementController shieldMovementController;
        
        private MenuState menuState;
        private GameState gameState;
        
        private BaseState currentlyActiveState;

        private UnityAction toGameStateTransition;

        private KnifeThrow knifeThrow;

        private void Start()
        {
            toGameStateTransition = () => ChangeState(gameState);
            
            inputSystem = new InputSystem();
            shieldMovementController = new ShieldMovementController();
            knifeThrow = new KnifeThrow();
            menuState = new MenuState(toGameStateTransition, menuView);
            gameState = new GameState(gameView, inputSystem, levelGenerator, 
                shieldMovementController, knifeThrow);
            
            ChangeState(menuState);
        }

        private void Update()
        {
            currentlyActiveState?.UpdateState();
        }

        private void OnDestroy()
        {
            
        }

        private void ChangeState(BaseState newState)
        {
            currentlyActiveState?.DestroyState();
            currentlyActiveState = newState;
            currentlyActiveState?.InitState();
        }
    }
}