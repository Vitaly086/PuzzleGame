using UnityEngine;
using Zenject;

namespace GameCore.Dice
{
    public class DiceManager : MonoBehaviour
    {
        [SerializeField]
        private int _diceValue = 1;
        [SerializeField]
        private Transform _spawnPoint;
        
        private DiceFactory _diceFactory;


        [Inject]
        private void Construct(DiceFactory diceFactory)
        {
            _diceFactory = diceFactory;
        }

        public void PushDice()
        {
            var dice = SpawnDice();
            dice.Push();
        }

        private DiceController SpawnDice()
        {
            var dice = _diceFactory.GetCube(_diceValue);
            dice.transform.position = _spawnPoint.position;
            return dice;
        }
    }
}