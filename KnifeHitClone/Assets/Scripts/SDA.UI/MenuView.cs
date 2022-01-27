using UnityEngine;
using UnityEngine.UI;

namespace SDA.UI
{
    public class MenuView : BaseView
    {
        [SerializeField]
        private Button playButton;
        public Button PlayButton => playButton;
        
        [SerializeField]
        private Button settingsButton;
        public Button SettingsButton => settingsButton;
        
        [SerializeField]
        private Button shopButton;
        public Button ShopButton => shopButton;


   

    
    }
}