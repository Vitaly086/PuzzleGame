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
        public DiceFaces DiceFaces {get; private set;}
        
        [field: SerializeField]
        public PhysicDice PhysicDice {get; private set;}

        private void Awake()
        {
            PhysicDice.Stopped += OnPhysicCubeStopped;
        }

        private void OnPhysicCubeStopped()
        {
            Stopped?.Invoke(this);
        }

        private void OnDestroy()
        {
            PhysicDice.Stopped -= OnPhysicCubeStopped;
        }
    }
}