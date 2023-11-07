using UnityEngine;

namespace GameCore.Dice
{
    public class DiceManager : MonoBehaviour
    {
        private DiceFactory _diceFactory;

        private void Construct(DiceFactory diceFactory)
        {
            _diceFactory = diceFactory;
        }
    }
}