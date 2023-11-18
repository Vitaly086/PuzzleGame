using System.Collections.Generic;
using UnityEngine;

namespace GameCore.Dice
{
    public class DicePusher
    {
        private readonly List<Transform> _spawnPoints;

        private readonly HashSet<int> _usedSpawnPoints = new();
        private readonly DiceFactory _diceFactory;


        public DicePusher(DiceFactory diceFactory, ISpawnPoints spawnPoints)
        {
            _diceFactory = diceFactory;
            _spawnPoints = spawnPoints.Points;
        }

        public IEnumerable<Dice> PushDice()
        {
            var dices = _diceFactory.GetCubes(false);
            _usedSpawnPoints.Clear();

            foreach (var dice in dices)
            {
                SpawnDice(dice);
            }

            return dices;
        }

        private void SpawnDice(Dice dice)
        {
            var spawnIndex = GetUniqueSpawnPointIndex();
            var spawnPoint = _spawnPoints[spawnIndex];
            dice.transform.position = spawnPoint.position;
            dice.gameObject.SetActive(true);
            dice.Push();
        }

        private int GetUniqueSpawnPointIndex()
        {
            int index;
            do
            {
                index = Random.Range(0, _spawnPoints.Count);
            } while (_usedSpawnPoints.Contains(index) && _usedSpawnPoints.Count < _spawnPoints.Count);

            _usedSpawnPoints.Add(index);
            return index;
        }
    }
}