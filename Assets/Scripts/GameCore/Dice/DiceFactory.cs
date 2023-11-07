using System.Collections.Generic;
using Zenject;

namespace GameCore.Dice
{
    public class DiceFactory
    {
        private readonly DiContainer _container;
        private readonly DiceHandConfigProvider _diceHandConfigProvider;

        public DiceFactory(DiContainer container, DiceHandConfigProvider diceHandConfigProvider)
        {
            _container = container;
            _diceHandConfigProvider = diceHandConfigProvider;
        }

        public IEnumerable<DiceController> GetCubes(bool isActive = true)
        {
            var dices = new List<DiceController>();
            foreach (var diceController in _diceHandConfigProvider.DicePrefabs)
            {
                var dice = _container.InstantiatePrefabForComponent<DiceController>(diceController);
                dice.gameObject.SetActive(isActive);
                dices.Add(dice);
            }

            return dices;
        }
    }
}