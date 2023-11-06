using Environment;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class EnvironmentInstaller : MonoInstaller
    {
        [SerializeField]
        private Camera _mainCamera;


        public override void InstallBindings()
        {
            Container.BindInstance(_mainCamera);
            Container.Bind<CameraFoVAdjuster>().AsTransient().NonLazy();
        }
    }
}