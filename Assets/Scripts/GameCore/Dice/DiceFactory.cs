using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GameCore.Dice
{
    public class DiceFactory
    {
        private readonly DiContainer _container;
        private readonly Dictionary<int, Dice> _cubePrefabs;

        public DiceFactory(DiContainer container, Dictionary<int, Dice> cubePrefabs)
        {
            _container = container;
            _cubePrefabs = cubePrefabs;
        }

        public Dice GetCube(int value)
        {
            if (!_cubePrefabs.TryGetValue(value, out var prefab))
            {
                throw new ArgumentException($"{typeof(Dice)} for value {value} not found!");
            }

            var dice = _container.InstantiatePrefabForComponent<Dice>(prefab);

            return dice;
        }
    }
}