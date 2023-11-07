using UnityEngine;

namespace GameCore.Dice
{
    [CreateAssetMenu(fileName = "DicePrefab", menuName = "GameCore/DicePrefab", order = 1)]
    public class DicePrefab : ScriptableObject
    {
        [field: SerializeField]
        public GameObject Prefab { get; private set; }

        [field: SerializeField]
        public int Value { get; private set; }
    }
}