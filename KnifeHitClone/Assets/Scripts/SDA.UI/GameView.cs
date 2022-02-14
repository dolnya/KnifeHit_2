using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SDA.UI
{
    public class GameView : BaseView
    {

        [SerializeField]
        private DotElement[] elements;
        [SerializeField]
        private TextMeshProUGUI stageText;


        [SerializeField]
        private KnifeAmmoDisplay knifeAmmoPrefab;


        [SerializeField]
        private RectTransform knifeElementContent;

        private List<KnifeAmmoDisplay> spawnedKnifes = new List<KnifeAmmoDisplay>();

        private int lastDeletedKnife;


        public void SpawnAmmo(int amount)
        {
            DespawnAmmo();

            for (int i = 0; i < amount; ++i)
            {
                var newKnife = Instantiate(knifeAmmoPrefab, knifeElementContent);
                spawnedKnifes.Add(newKnife);
                newKnife.MarkAsUnlocked();
            }

            lastDeletedKnife = -1;
        }

        private void DespawnAmmo()
        {
            for (int i = spawnedKnifes.Count - 1; i >= 0; i--)
            {
                Destroy(spawnedKnifes[i].gameObject);
            }
            spawnedKnifes.Clear();
        }


        public void DecreaseAmmo()
        {
            lastDeletedKnife++;
            spawnedKnifes[lastDeletedKnife].MarkAsLocked();
        }

        public void UpdateStage(int currentStage)
        {
            if (currentStage == 0)
            {
                stageText.color = Color.red;
                stageText.text = $"BOSS FIGHT";
                for (int i = 0; i < elements.Length; ++i)
                {
                    elements[i].gameObject.SetActive(false);
                }
                elements[elements.Length - 1].gameObject.SetActive(true);
            }
            else
            {
                if (currentStage == 1)
                {
                    for (int i = 0; i < elements.Length; ++i)
                    {
                        elements[i].gameObject.SetActive(true);
                        elements[i].MarkAsLocked();
                    }
                    elements[elements.Length - 1].gameObject.SetActive(false);
                }

                elements[currentStage - 1].MarkAsUnlocked();
                stageText.color = Color.white;
                stageText.text = $"STAGE {currentStage}";
            }

        }

    }
}