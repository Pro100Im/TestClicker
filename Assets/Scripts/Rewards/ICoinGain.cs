using System;

namespace Rewards
{
    public interface ICoinGain
    {
        public event Action<int> OnCoinGained;
    }
}
