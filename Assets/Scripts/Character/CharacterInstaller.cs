using Zenject;

namespace Character
{
    public class CharacterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CharacterAnimator>()
                .FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterMovement>()
                .FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterGroundChecker>()
                .FromComponentInHierarchy().AsSingle();
        }
    }
}
