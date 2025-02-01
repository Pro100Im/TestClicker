using Rewards;
using TMPro;
using UnityEngine;
using Zenject;

namespace GameUI.Score
{
    public class CoinScore : MonoBehaviour
    {
        [SerializeField] private string currency = "$"; 
        [SerializeField] private TextMeshProUGUI scoreText;
        
        [Inject] private ICoinGain coinGain;

        private int scoreValue;
        
        private void Awake()
        {
            scoreText.text = $"{currency}{scoreValue}";
        }

        private void Start()
        {
            coinGain.OnCoinGained += UpdateScore;
        }

        private void UpdateScore(int value)
        {
            scoreValue += value;
            scoreText.text = $"{currency}{scoreValue}";
        }
        
        private void OnDestroy()
        {
            coinGain.OnCoinGained -= UpdateScore;
        }
    }
}
