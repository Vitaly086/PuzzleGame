using System.Collections.Generic;
using GameCore.Dice;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class DiceInstaller : MonoInstaller
    {
        [SerializeField]
        private DiceSettings _diceSettings;
        [SerializeField]
        private List<DicePrefab> _dicePrefabAssets;


        public override void InstallBindings()
        {
            var prefabsDictionary = new Dictionary<int, GameObject>();
            foreach (var dicePrefabAsset in _dicePrefabAssets)
            {
                prefabsDictionary.Add(dicePrefabAsset.Value, dicePrefabAsset.Prefab);
            }

            Container.BindInstance(_diceSettings).AsTransient();
            Container.Bind<DiceFactory>().AsSingle().WithArguments(prefabsDictionary);
        }
    }
}