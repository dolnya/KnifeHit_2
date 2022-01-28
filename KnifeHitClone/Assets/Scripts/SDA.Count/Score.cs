using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace SDA.Count
{
    public class Score : MonoBehaviour
    {
        [SerializeField]
        public TextMeshProUGUI scoreCountMenu;
        [SerializeField]
        public TextMeshProUGUI scoreCountGame;
        [SerializeField]
        public TextMeshProUGUI currencyCountMenu;
        [SerializeField]
        public TextMeshProUGUI currencyCountGame;
        [SerializeField]
        public TextMeshProUGUI currencyCountShop;
        int score; 
        int currency;
        
        public void InitScore()
        {
            score = 0;
            scoreCountGame.text = $"{score}";
            scoreCountMenu.text = $"SCORE {score}";
            Debug.Log(score.ToString());
        }
        public void InitCurrency()
        {
            currency = 0;
            currencyCountMenu.text = $"SCORE {currency}";
            currencyCountGame.text = $"{currency}";
            currencyCountShop.text = $"{currency}";
            Debug.Log(score.ToString());
        }

        public void UpdateScore()
        {
            score++;
            scoreCountGame.text = $"{score}";
            scoreCountMenu.text = $"SCORE {score}";
            Debug.Log("Update Score");
        }
        public void UpdateCurrency()
        {
            currency++;
            currencyCountGame.text = $"{currency}";
            currencyCountGame.text = $"{currency}";
            currencyCountShop.text = $"{currency}";
            Debug.Log("Update Currency");
        }
    }
}
