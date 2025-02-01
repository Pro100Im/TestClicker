using UnityEngine;
using Zenject;

namespace Level.Gradient
{
    public class GroundGradientState : GradientState
    {
        [Inject] private SkyGradientState _nextGradientState;
        
        public GroundGradientState(GradientData data, float maxPos, float minPos) : base(data,maxPos, minPos)
        {
            
        }

        public override void CheckStateByDistance(float pos, SpriteRenderer gradient)
        {
            if (pos > MinPos)
            {
                if(!CheckNextStateIsHighest(pos, _nextGradientState))
                    SetNextState(_nextGradientState, gradient);
                else
                    _nextGradientState.CheckStateByDistance(pos, gradient);
            }
            else
            {
                SetNextState(this, gradient);
            }
        }
    }
}
