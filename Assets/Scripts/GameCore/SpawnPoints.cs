using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public class SpawnPoints : MonoBehaviour, ISpawnPoints
    {
        [field: SerializeField]
        public List<Transform> Points { get; private set; }
    }
}