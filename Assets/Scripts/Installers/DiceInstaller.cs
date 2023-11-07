using System.Collections.Generic;
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
        private List<DicePrefab> _dicePrefabAssets;
        [SerializeField]
        private Target _target;
        [SerializeField]
        private DiceFacesProvider _diceFacesProvider;
        [SerializeField]
        private DiceFacesSettings _diceFacesSettings;

        public override void InstallBindings()
        {
            BindDiceSetup();
            BindTargetSetup();
            BindProviderSetup();
        }

        private void BindDiceSetup()
        {
            var prefabsDictionary = new Dictionary<int, DiceController>();
            foreach (var dicePrefabAsset in _dicePrefabAssets)
            {
                prefabsDictionary.Add(dicePrefabAsset.Value, dicePrefabAsset.Prefab);
            }

            Container.Bind<DiceFactory>().AsSingle().WithArguments(prefabsDictionary);
            Container.BindInstance(_dicePhysicSettings).AsTransient();
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