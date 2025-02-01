using UnityEngine;
using Zenject;

namespace Character.Animation
{
    public class FallAnimationState : CharacterAnimationState
    {
        [Inject] private IdleFlyAnimationState _nextState;
        [Inject] private IdleAnimationState _prevState;
        
        [Inject] private IGetIsGrounded _groundChecker;
        
        private float _maxSpeed;
        
        public FallAnimationState(float maxSpeed)
        {
            _maxSpeed = maxSpeed;
        } 
        
        public override void CheckStateBySpeed(float speed)
        {
            var isGrounded = _groundChecker.GetIsGrounded();
            
            if (isGrounded)
            {
                SetNextAnimState(Context.IdleAnim, _prevState);
                Debug.Log("Grounded");
            }
            else if(_maxSpeed < speed)
            {
                SetNextAnimState(Context.IdleFlyAnim, _nextState);
            }
        }
    }
}
