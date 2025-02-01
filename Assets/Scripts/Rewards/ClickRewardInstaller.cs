using Zenject;

namespace Rewards
{
    public class ClickRewardInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ClickReward>().FromComponentInHierarchy().AsSingle();
        }
    }
}
