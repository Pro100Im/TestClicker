using System;
using CustomInput;
using UnityEngine;
using Zenject;

namespace Rewards
{
    public class ClickReward : MonoBehaviour, ICoinGain
    {
        public event Action<int> OnCoinGained;
        
        [SerializeField] private int clickRate = 3;
        
        [Inject] private IClickDetect clickDetect;

        private void Start()
        {
            clickDetect.OnClick += GainCoin;
        }

        private void GainCoin()
        {
            OnCoinGained?.Invoke(clickRate);
        }

        private void OnDestroy()
        {
            clickDetect.OnClick -= GainCoin;
        }
    }
}
