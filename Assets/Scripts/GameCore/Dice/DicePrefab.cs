using UnityEngine;

namespace GameCore.Dice
{
    [CreateAssetMenu(fileName = "DicePrefab", menuName = "Dice/Dice Prefab", order = 1)]
    public class DicePrefab : ScriptableObject
    {
        [field: SerializeField]
        public DiceController Prefab { get; private set; }

        [field: SerializeField]
        public int Value { get; private set; }
    }
}