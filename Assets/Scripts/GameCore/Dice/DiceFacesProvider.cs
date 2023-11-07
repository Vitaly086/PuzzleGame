using System;
using UnityEngine;

namespace GameCore.Dice
{
    [CreateAssetMenu(fileName = "DiceFacesProvider", menuName = "Dice/DiceFacesProvider")]
    public class DiceFacesProvider : ScriptableObject
    {
        [SerializeField]
        private DiceFace[] _uniqueFacePrefabs;
        [SerializeField]
        private DiceFace _commonFacePrefab;


        public DiceFace GetFacePrefab(int faceValue)
        {
            switch (faceValue)
            {
                case >= 1 and <= 9:
                    return _uniqueFacePrefabs[faceValue - 1];
                case >= 10:
                    return _commonFacePrefab;
                default:
                    throw new ArgumentException("Invalid face value, must be 1 or greater.");
            }
        }
    }
}