using Character.Animation;
using Spine.Unity;
using UnityEngine;
using Zenject;

namespace Character
{
    public class CharacterAnimator : MonoBehaviour
    {
        [field: SerializeField] public SkeletonAnimation SkeletonAnimation { get; private set; }

        [field: SpineAnimation, SerializeField]
        public string IdleAnim { get; private set; }
        [field: SpineAnimation, SerializeField]
        public string IdleFlyAnim { get; private set; }
        [field: SpineAnimation, SerializeField]
        public string FlyRate1Anim { get; private set; }
        [field: SpineAnimation, SerializeField]
        public string FlyRate2Anim { get; private set; }
        [field: SpineAnimation, SerializeField]
        public string FlyRate3Anim { get; private set; }
        [field: SpineAnimation, SerializeField]
        public string FlyRate4Anim { get; private set; }
        [field: SpineAnimation, SerializeField]
        public string HitAnim { get; private set; }
        [field: SpineAnimation, SerializeField]
        public string FallAnim { get; private set; }

        [Inject] private IdleAnimationState _idleAnimationState;
        [Inject] private ICharacterSpeedChange _speedChange;
        
        private CharacterAnimationState _characterAnimationState;
        
        private void Awake()
        {
            TransitionToAnimationState(_idleAnimationState);
        }

        private void Start()
        {
            _speedChange.OnSpeedChanged += CheckBySpeed;
        }

        public void TransitionToAnimationState(CharacterAnimationState state)
        {
            _characterAnimationState = state;
        }

        private void CheckBySpeed(float speed)
        {
            _characterAnimationState.CheckStateBySpeed(speed);
        }

        private void OnDestroy()
        {
            _speedChange.OnSpeedChanged -= CheckBySpeed;
        }
    }
}