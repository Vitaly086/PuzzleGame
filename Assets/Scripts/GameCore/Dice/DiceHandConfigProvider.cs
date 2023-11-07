using UnityEngine;

namespace GameCore.Dice
{
    [CreateAssetMenu(fileName = "DiceHandConfigProvider", menuName = "Dice/DiceHandConfigProvider")]
    public class DiceHandConfigProvider : ScriptableObject
    {
        [field: SerializeField]
        public Dice[] DicePrefabs { get; private set; }
    }
}