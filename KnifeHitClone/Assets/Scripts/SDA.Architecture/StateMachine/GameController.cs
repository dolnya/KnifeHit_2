using SDA.CoreGameplay;
using SDA.Count;
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
        private SettingsView settingsView;
        [SerializeField]
        private ShopView shopView;
        [SerializeField]
        private EndView endView;

        [SerializeField]
        private LevelGenerator levelGenerator;
        [SerializeField]
        private Score scoreclass;

        private InputSystem inputSystem;
        private ShieldMovementController shieldMovementController;

        private BaseState currentlyActiveState;
        private MenuState menuState;
        private GameState gameState;
        private SettingsState settingsState;
        private ShopState shopState;
        private EndState endState;

        private StageController stageController;

        private UnityAction toGameStateTransition;
        private UnityAction toSettingsStateTransition;
        private UnityAction toMenuStateTransition;
        private UnityAction toShopStateTransition;
        private UnityAction toEndStateTransition;
        private KnifeThrow knifeThrow;

        private void Start()
        {
            toGameStateTransition = () => ChangeState(gameState);
            toMenuStateTransition = () => ChangeState(menuState);
            toSettingsStateTransition = () => ChangeState(settingsState);
            toShopStateTransition = () => ChangeState(shopState);
            toEndStateTransition = () => ChangeState(endState);

            stageController = new StageController();
            inputSystem = new InputSystem();
            shieldMovementController = new ShieldMovementController();
            knifeThrow = new KnifeThrow();
            menuState = new MenuState(toGameStateTransition, toSettingsStateTransition,
                toShopStateTransition, menuView);
            gameState = new GameState(gameView, inputSystem, levelGenerator,
                shieldMovementController, knifeThrow, toEndStateTransition,
                scoreclass, stageController);

            settingsState = new SettingsState(toMenuStateTransition, settingsView);
            shopState = new ShopState(toMenuStateTransition, shopView);
            endState = new EndState(toMenuStateTransition, endView, toGameStateTransition,
                stageController);

            ChangeState(menuState);
            scoreclass.InitCurrency();
            scoreclass.InitScore();
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