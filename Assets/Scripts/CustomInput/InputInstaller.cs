using Zenject;

namespace CustomInput
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InputDetector>().FromComponentInHierarchy().AsSingle();
        }
    }
}
