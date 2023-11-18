using Score;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ScoreInstallers : MonoInstaller
    {
        [SerializeField]
        private ScoreView _scoreView;


        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ScoreController>().AsSingle();
            Container.BindInstance(_scoreView).AsSingle();
        }
    }
}