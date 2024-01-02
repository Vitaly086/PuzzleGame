using System;
using UnityEngine;

namespace GameCore.DiceDatas
{
    [CreateAssetMenu(fileName = "DicePrefabLibrary", menuName = "Dice/DicePrefabLibrary")]
    public class DicePrefabLibrary : ScriptableObject
    {
        [field: SerializeField]
        public GameObject BasicDicePrefab { get; private set; }


        public GameObject GetPrefab(DicePrefabType type)
        {
            switch (type)
            {
                case DicePrefabType.BasicDice:
                    return BasicDicePrefab;
            }

            throw new ArgumentException("No prefab found for the provided DicePrefabType: " + type);
        }
    }
}