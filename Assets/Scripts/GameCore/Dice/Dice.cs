using System;
using GameCore.Settings;
using UnityEngine;

namespace GameCore.Dice
{
    /// <summary>
    /// Кубик - содержит в себе 2 части: грани с их значениями и физическую составляющую кубика
    /// </summary>
    [RequireComponent(typeof(DiceFaces), typeof(PhysicDice))]
    public class Dice : MonoBehaviour
    {
        public event Action<Dice> Stopped;

        private DiceFaces _diceFaces;
        private PhysicDice _physicDice;
        
        
        public void Initialize(DiceFacesConfig diceFacesConfig, DiceFaceFactory faceFactory)
        {
            _diceFaces = GetComponent<DiceFaces>();
            _physicDice = GetComponent<PhysicDice>();
            _diceFaces.Initialize(faceFactory, diceFacesConfig);

            _physicDice.Stopped += OnPhysicCubeStopped;
        }

        public void Push()
        {
            _physicDice.Push();
        }

        public Transform[] GetFacesRoot() => _diceFaces.FacesRoots;

        public int GetFaceValue(int faceIndex)
        {
            return _diceFaces.FacesConfig[faceIndex];
        }

        private void OnPhysicCubeStopped()
        {
            Stopped?.Invoke(this);
        }

        private void OnDestroy()
        {
            _physicDice.Stopped -= OnPhysicCubeStopped;
        }
    }
}