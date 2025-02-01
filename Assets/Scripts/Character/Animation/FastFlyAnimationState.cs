using Zenject;

namespace Character.Animation
{
    public class FastFlyAnimationState : CharacterAnimationState
    {
        [Inject] private FastestFlyAnimationState _nextState;
        [Inject] private SlowFlyAnimationState _prevState;
        
        private float _maxSpeed;
        private float _minSpeed;
        
        public FastFlyAnimationState (float maxSpeed, float minSpeed)
        {
            _maxSpeed = maxSpeed;
            _minSpeed = minSpeed;
        } 
        
        public override void CheckStateBySpeed(float speed)
        {
            if (_maxSpeed < speed)
            {
                SetNextAnimState(Context.FlyRate4Anim, _nextState);
            }
            else if (_minSpeed > speed)
            {
                SetNextAnimState(Context.FlyRate1Anim, _prevState);
            }
        }
    }
}
