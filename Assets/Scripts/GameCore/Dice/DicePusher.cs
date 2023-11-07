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

        public async void PushDice() //todo изменить тип возвращаемого значения после того как уберем с нажатия кнопки.
        {
            var diceControllers = _diceFactory.GetCubes(false);
            _usedSpawnPoints.Clear();

            foreach (var diceController in diceControllers)
            {
                SpawnDice(diceController);
                await UniTask.WaitForSeconds(0.2f);
            }
        }

        private void SpawnDice(PhysicDice diceController)
        {
            var spawnIndex = GetUniqueSpawnPointIndex();
            var spawnPoint = _spawnPoints[spawnIndex];
            diceController.transform.position = spawnPoint.position;
            diceController.gameObject.SetActive(true);
            diceController.Push();
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