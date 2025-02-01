using Zenject;

namespace Character.Animation
{
    public abstract class CharacterAnimationState
    {
        [Inject] protected CharacterAnimator Context;
        
        public abstract void CheckStateBySpeed(float speed);

        protected void SetNextAnimState(string animName, CharacterAnimationState state)
        {
            Context.SkeletonAnimation.AnimationState.SetAnimation(0, animName, true);
            Context.TransitionToAnimationState(state);
        }

        protected void HitState()
        {
            //SetNextAnimState(Context.HitAnim);
        }
    }
}
