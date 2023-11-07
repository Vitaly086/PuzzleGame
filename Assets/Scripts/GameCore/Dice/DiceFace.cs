using System;
using UnityEngine;

namespace GameCore.Dice
{
    [Serializable]
    public class DiceFace
    {
        [field: SerializeField]
        public int Value { get; set; }
    }
}