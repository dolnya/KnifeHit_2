using UnityEngine;
using UnityEngine.UI;
namespace SDA.UI
{
    public class SettingsView : BaseView
    {
        [SerializeField]
        private Button backSettingsButton;

        public Button BackSettingsButton => backSettingsButton;
    }
}
