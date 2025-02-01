using UnityEngine;
using Zenject;

namespace Level.Gradient
{
    public class SpaceGradientState : GradientState
    {
        [Inject] private ExoSphereGradientState _prevGradientState;
        
        public SpaceGradientState(GradientData data,float maxPos, float minPos) : base(data, maxPos, minPos)
        {
        }

        public override void CheckStateByDistance(float pos, SpriteRenderer gradient)
        {
            if(pos <= MinPos)
                if(!CheckPrevStateIsLower(pos, _prevGradientState))
                    SetNextState(_prevGradientState, gradient);
                else
                    _prevGradientState.CheckStateByDistance(pos, gradient);
            else
                SetNextState(this, gradient);
        }
    }
}
