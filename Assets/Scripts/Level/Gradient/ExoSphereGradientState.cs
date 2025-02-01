using UnityEngine;
using Zenject;

namespace Level.Gradient
{
    public class ExoSphereGradientState : GradientState
    {
        [Inject] private SpaceGradientState _nextGradientState;
        [Inject] private TropoSphereGradientState _prevGradientState;

        public ExoSphereGradientState(GradientData data, float maxPos, float minPos) :  base(data, maxPos, minPos)
        {
        }

        public override void CheckStateByDistance(float pos, SpriteRenderer gradient)
        {
            if (pos >= MaxPos)
                if(!CheckNextStateIsHighest(pos, _nextGradientState))
                    SetNextState(_nextGradientState, gradient);
                else
                    _nextGradientState.CheckStateByDistance(pos, gradient);

            if (pos <= MinPos)
                if(!CheckPrevStateIsLower(pos, _prevGradientState))
                    SetNextState(_prevGradientState, gradient);
                else
                    _prevGradientState.CheckStateByDistance(pos, gradient);
        }
    }
}