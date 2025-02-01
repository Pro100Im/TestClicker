using Zenject;

namespace Character.Animation
{
    public class SlowFlyAnimationState : CharacterAnimationState
    {
        [Inject] private FastFlyAnimationState  _nextState;
        [Inject] private IdleFlyAnimationState _prevState;
        
        private float _maxSpeed;
        private float _minSpeed;
        
        public SlowFlyAnimationState(float maxSpeed, float minSpeed)
        {
            _maxSpeed = maxSpeed;
            _minSpeed = minSpeed;
        } 
        
        public override void CheckStateBySpeed(float speed)
        {
            if (_maxSpeed < speed)
            {
                SetNextAnimState(Context.FlyRate2Anim, _nextState);
            }
            else if (_minSpeed > speed)
            {
                SetNextAnimState(Context.IdleFlyAnim, _prevState);
            }
        }
    }
}
