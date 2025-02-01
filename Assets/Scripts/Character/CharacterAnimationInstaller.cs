using Character.Animation;
using UnityEngine;
using Zenject;

namespace Character
{
    public class CharacterAnimationInstaller : MonoInstaller
    {
        [SerializeField] private float slowFlyMaxSpeed;
        [SerializeField] private float slowFlyMinSpeed;
        [SerializeField] private float fastFlyMaxSpeed;
        [SerializeField] private float fastFlyMinSpeed;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<FallAnimationState>()
                .FromNew().AsSingle().WithArguments(0f);
            Container.BindInterfacesAndSelfTo<IdleAnimationState>()
                .FromNew().AsSingle().WithArguments(0f);
            Container.BindInterfacesAndSelfTo<FastestFlyAnimationState>()
                .FromNew().AsSingle().WithArguments(fastFlyMaxSpeed);
            
            Container.BindInterfacesAndSelfTo<IdleFlyAnimationState>()
                .FromNew().AsSingle().WithArguments(0f, -1f);
            Container.BindInterfacesAndSelfTo<SlowFlyAnimationState>()
                .FromNew().AsSingle().WithArguments(slowFlyMaxSpeed, slowFlyMinSpeed);
            Container.BindInterfacesAndSelfTo<FastFlyAnimationState>()
                .FromNew().AsSingle().WithArguments(fastFlyMaxSpeed, fastFlyMinSpeed);
        }
    }
}
