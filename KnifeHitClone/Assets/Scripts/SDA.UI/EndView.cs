using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SDA.UI
{
    public class EndView : BaseView
    {
        [SerializeField]
        private Button restartButton;
        public Button RestartButton => restartButton;

        [SerializeField]
        private Button menuButton;
        public Button MenuButton => menuButton;


        [SerializeField] private TextMeshProUGUI stageText;
        [SerializeField] private TextMeshProUGUI pointsText;


        public void UpdatePointsAndStage(int points, int stage)
        {
            stageText.text = $"STAGE {stage}";
            pointsText.text = points.ToString();
        }

    }
}