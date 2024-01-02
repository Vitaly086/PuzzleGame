using GameCore.Dice;
using GameCore.DiceDatas;
using GameCore.Settings;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        [SerializeField]
        private DefaultDiceFacesConfig _defaultDiceFacesConfig;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<HandWithDices>().AsSingle();
            Container.Bind<DiceDataManager>().AsSingle().WithArguments(_defaultDiceFacesConfig);
        }
    }
}