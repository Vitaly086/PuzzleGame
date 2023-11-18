using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public interface ISpawnPoints
    {
        List<Transform> Points { get; }
    }
}