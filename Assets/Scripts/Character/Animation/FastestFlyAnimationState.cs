using Zenject;

namespace Character.Animation
{
    public class FastestFlyAnimationState : CharacterAnimationState
    {
        [Inject] private FastFlyAnimationState _prevState;
        
        private float _minSpeed;
        
        public FastestFlyAnimationState ( float minSpeed)
        {
            _minSpeed = minSpeed;
        } 
        
        public override void CheckStateBySpeed(float speed)
        {
            if (_minSpeed > speed)
            {
                SetNextAnimState(Context.FlyRate2Anim, _prevState);
            }
        }
    }
}
