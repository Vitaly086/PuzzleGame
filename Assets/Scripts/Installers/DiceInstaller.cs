using GameCore;
using GameCore.Dice;
using GameCore.DiceDatas;
using GameCore.Settings;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class DiceInstaller : MonoInstaller
    {
        [SerializeField]
        private DicePhysicSettings _dicePhysicSettings;
        [SerializeField]
        private Target _target;
        [SerializeField]
        private DiceFacesProvider _diceFacesProvider;
        [SerializeField]
        private SpawnPoints _spawnPoints;
        [SerializeField]
        private DiceRoller _diceRoller;
        [SerializeField]
        private DicePrefabLibrary _dicePrefabLibrary;
        
        public override void InstallBindings()
        {
            BindDiceSetup();
            BindTargetSetup();
            BindProviderSetup();
            BindFactorySetup();
        }

        private void BindDiceSetup()
        {
            Container.Bind<DicePusher>().AsSingle().WithArguments(_spawnPoints);
            Container.BindInstance(_dicePhysicSettings).AsTransient();
            Container.BindInstance(_diceRoller).AsSingle();
            Container.BindInstance(_dicePrefabLibrary).AsSingle();
        }

        private void BindTargetSetup()
        {
            Container.Bind<ITarget>().FromInstance(_target).AsSingle();
        }

        private void BindProviderSetup()
        {
            Container.BindInstance(_diceFacesProvider).AsSingle();
        }
        
        private void BindFactorySetup()
        {
            Container.Bind<DiceFactory>().AsSingle();
            Container.Bind<DiceFaceFactory>().AsSingle();
        }
    }
}