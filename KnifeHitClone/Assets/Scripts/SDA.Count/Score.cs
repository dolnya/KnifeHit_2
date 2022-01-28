using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace SDA.Count
{
    public class Score : MonoBehaviour
    {
        [SerializeField]
        public TextMeshProUGUI scoreCount;
        [SerializeField]
        public TextMeshProUGUI currencyCount;
        int score; 
        int currency;
        
        public void InitScore()
        {
            score = 0;
            scoreCount.text = $"{score}";
            Debug.Log(score.ToString());
        }
            
        public void UpdateScore()
        {
            score++;
            scoreCount.text = $"{score}";
            Debug.Log("Update Score");
        }
        public void UpdateCurrency()
        {
            //currencyCount.text = currency.ToString();
            Debug.Log("Update Currency");
        }
    }
}
