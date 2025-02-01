using Zenject;

namespace Character.Animation
{
    public class IdleAnimationState : CharacterAnimationState
    {
        [Inject] private IdleFlyAnimationState _nextState;
        
        private float _maxSpeed;
        
        public IdleAnimationState(float maxSpeed)
        {
            _maxSpeed = maxSpeed;
        }
        
        public override void CheckStateBySpeed(float speed)
        {
            if (_maxSpeed >= speed) return;
            
            SetNextAnimState(Context.IdleFlyAnim, _nextState);
        }
    }
}
