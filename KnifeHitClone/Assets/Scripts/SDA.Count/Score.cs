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
        
        
        public void UpdateScore()
        {
        
            Debug.Log("Update Score");
        }
        public void UpdateCurrency()
        {

            Debug.Log("Update Currency");
        }
    }
}
