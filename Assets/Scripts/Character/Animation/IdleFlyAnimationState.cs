using Unity.Mathematics;
using Zenject;

namespace Character.Animation
{
    public class IdleFlyAnimationState : CharacterAnimationState
    {
        [Inject] private SlowFlyAnimationState _nextState;
        [Inject] private FallAnimationState _prevState;
        
        private float _maxSpeed;
        private float _minSpeed;
        
        public IdleFlyAnimationState(float maxSpeed, float minSpeed)
        {
            _maxSpeed = maxSpeed;
            _minSpeed = minSpeed;
        } 
        
        public override void CheckStateBySpeed(float speed)
        {
            if (_maxSpeed < speed)
            {
                SetNextAnimState(Context.FlyRate1Anim, _nextState);
            }
            else if (math.abs(_minSpeed) >= math.abs(speed))
            {
                SetNextAnimState(Context.FallAnim, _prevState);
            }
        }
    }
}
