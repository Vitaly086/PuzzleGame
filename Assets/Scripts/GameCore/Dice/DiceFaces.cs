using System;
using System.Linq;
using GameCore.Settings;
using UnityEngine;

namespace GameCore.Dice
{
    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
    public class DiceFaces : MonoBehaviour
    {
        [field: SerializeField] public Transform[] FacesRoots { get; set; }
        public DiceFacesConfig FacesConfig { get; private set; }
        
        private DiceFaceFactory _diceFaceFactory;

        public void Initialize(DiceFaceFactory diceFaceFactory, DiceFacesConfig diceFacesConfig)
        {
            _diceFaceFactory = diceFaceFactory;
            FacesConfig = diceFacesConfig;
            CreateDiceFaces(diceFacesConfig.DiceFaces.Select(face => face.Value).ToArray());
        }

        private void CreateDiceFaces(int[] diceFacesValues)
        {
            if (FacesRoots.Length != diceFacesValues.Length)
            {
                throw new InvalidOperationException(
                    "The number of dice face values does not match the number of face roots.");
            }

            for (int i = 0; i < FacesRoots.Length; i++)
            {
                var diceFaceInstance = _diceFaceFactory.GetFace(diceFacesValues[i]);
                diceFaceInstance.transform.SetParent(FacesRoots[i], worldPositionStays: false);
            }
        }
    }
}