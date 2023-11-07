using System;
using ModestTree.Util;
using UnityEngine;

namespace GameCore.Dice
{
    /// <summary>
    /// Кубик - содержит в себе 2 части: грани с их значениями и физическую составляющую кубика
    /// </summary>
    public class Dice : MonoBehaviour
    {
        public Action<Dice> Stopped;
        
        [field: SerializeField]
        public DiceFaces DiceFaces;
        
        [field: SerializeField]
        public PhysicDice PhysicDice;

        private void Awake()
        {
            PhysicDice.Stopped += _ => Stopped?.Invoke(this);
        }

        private void OnDestroy()
        {
            PhysicDice.Stopped -= _ => Stopped?.Invoke(this);
        }
    }
}