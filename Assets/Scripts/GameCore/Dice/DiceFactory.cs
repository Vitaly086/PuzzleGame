using System;
using System.Collections.Generic;
using Zenject;

namespace GameCore.Dice
{
    public class DiceFactory
    {
        private readonly DiContainer _container;
        private readonly Dictionary<int, DiceController> _cubePrefabs;

        public DiceFactory(DiContainer container, Dictionary<int, DiceController> cubePrefabs)
        {
            _container = container;
            _cubePrefabs = cubePrefabs;
        }

        public DiceController GetCube(int value)
        {
            if (!_cubePrefabs.TryGetValue(value, out var prefab))
            {
                throw new ArgumentException($"{typeof(DiceController)} for value {value} not found!");
            }

            var dice = _container.InstantiatePrefabForComponent<DiceController>(prefab);

            return dice;
        }
    }
}