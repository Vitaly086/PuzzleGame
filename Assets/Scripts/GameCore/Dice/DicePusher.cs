using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace GameCore.Dice
{
    public class DicePusher : MonoBehaviour
    {
        [SerializeField]
        private List<Transform> _spawnPoints;

        private readonly HashSet<int> _usedSpawnPoints = new();
        private DiceFactory _diceFactory;

        [Inject]
        private void Construct(DiceFactory diceFactory)
        {
            _diceFactory = diceFactory;
        }

        public IEnumerable<PhysicDice> PushDice()
        {
            var dices = _diceFactory.GetCubes(false);
            _usedSpawnPoints.Clear();

            foreach (var dice in dices)
            {
                SpawnDice(dice);
            }

            return dices;
        }

        private void SpawnDice(PhysicDice dice)
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