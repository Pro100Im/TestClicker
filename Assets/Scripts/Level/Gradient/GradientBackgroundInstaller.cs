using UnityEngine;
using Zenject;

namespace Level.Gradient
{
    public class GradientBackgroundInstaller : MonoInstaller
    {
        [SerializeField] private GradientData groundData;
        [SerializeField] private GradientData skyData;
        [SerializeField] private GradientData tropoData;
        [SerializeField] private GradientData exoData;
        [SerializeField] private GradientData spaceData;
        [Space]
        [SerializeField] private float minSkyPos;
        [SerializeField] private float maxSkyPos;
        [SerializeField] private float minTropoPos;
        [SerializeField] private float maxTropoPos;
        [SerializeField] private float minExoPos;
        [SerializeField] private float maxExoPos;
        [SerializeField] private float minSpacePos;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GradientBackground>().FromComponentInHierarchy().AsCached();
            
            Container.BindInterfacesAndSelfTo<GroundGradientState>()
                .FromNew().AsSingle().WithArguments(groundData, 0f, 0f);
            
            Container.BindInterfacesAndSelfTo<SkyGradientState>()
                .FromNew().AsSingle().WithArguments(skyData, maxSkyPos, minSkyPos);
            
            Container.BindInterfacesAndSelfTo<TropoSphereGradientState>()
                .FromNew().AsSingle().WithArguments(tropoData, maxTropoPos, minTropoPos);
            
            Container.BindInterfacesAndSelfTo<ExoSphereGradientState>()
                .FromNew().AsSingle().WithArguments(exoData, maxExoPos, minExoPos);
            
            Container.BindInterfacesAndSelfTo<SpaceGradientState>()
                .FromNew().AsSingle().WithArguments(spaceData, minSpacePos, minSpacePos);
        }
    }
}
