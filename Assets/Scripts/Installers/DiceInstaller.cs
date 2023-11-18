using GameCore;
using GameCore.Dice;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class DiceInstaller : MonoInstaller
    {
        [SerializeField]
        private DicePhysicSettings _dicePhysicSettings;
        [SerializeField]
        private DiceHandConfigProvider _diceHandConfigProvider;
        [SerializeField]
        private Target _target;
        [SerializeField]
        private DiceFacesProvider _diceFacesProvider;
        [SerializeField]
        private DiceFacesSettings _diceFacesSettings;
        [SerializeField]
        private SpawnPoints _spawnPoints;
        [SerializeField]
        private DiceRoller _diceRoller;
        
        public override void InstallBindings()
        {
            BindDiceSetup();
            BindTargetSetup();
            BindProviderSetup();
        }

        private void BindDiceSetup()
        {
            Container.Bind<DiceFactory>().AsSingle().WithArguments(_diceHandConfigProvider);
            Container.Bind<DicePusher>().AsSingle().WithArguments(_spawnPoints);
            Container.BindInstance(_dicePhysicSettings).AsTransient();
            Container.BindInstance(_diceRoller);
        }

        private void BindTargetSetup()
        {
            Container.Bind<ITarget>().FromInstance(_target).AsSingle();
        }

        private void BindProviderSetup()
        {
            Container.Bind<DiceFaceFactory>().AsSingle();
            Container.BindInstance(_diceFacesProvider).AsSingle();
            Container.BindInstance(_diceFacesSettings).AsSingle();
        }
    }
}