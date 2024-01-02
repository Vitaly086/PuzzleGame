using System.Collections.Generic;
using GameCore.DiceDatas;
using GameCore.Settings;
using Zenject;

namespace GameCore.Dice
{
    public class DiceFactory
    {
        private readonly DiContainer _container;
        private readonly List<DiceFacesConfig> _diceConfigs;
        private readonly DiceFaceFactory _diceFaceFactory;
        private readonly DicePrefabLibrary _prefabLibrary;


        public DiceFactory(DiContainer container, DiceDataManager diceDataManager, DiceFaceFactory diceFaceFactory, DicePrefabLibrary prefabLibrary)
        {
            _container = container;
            _diceConfigs = diceDataManager.DiceFacesConfigs;
            _diceFaceFactory = diceFaceFactory;
            _prefabLibrary = prefabLibrary;
        }

        public IEnumerable<Dice> GetCubes(bool isActive = true)
        {
            var dices = new List<Dice>();
            foreach (var diceConfig in _diceConfigs)
            {
                var dicePrefab = _prefabLibrary.GetPrefab(diceConfig.DicePrefabType);
                var dice = _container.InstantiatePrefabForComponent<Dice>(dicePrefab.gameObject);
                dice.Initialize(diceConfig, _diceFaceFactory);
                dice.gameObject.SetActive(isActive);
                dices.Add(dice);
            }

            return dices;
        }
    }
}