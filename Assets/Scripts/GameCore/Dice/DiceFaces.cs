using System;
using System.Linq;
using Zenject;
using UnityEngine;

namespace GameCore.Dice
{
    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
    public class DiceFaces : MonoBehaviour
    {
        [field: SerializeField] public Transform[] FacesRoots { get; set; }
        [field: SerializeField] public DiceFacesSettings DiceFacesSettings { get; set; }
        
        private DiceFaceFactory _faceFactory;

        [Inject]
        private void Construct(DiceFaceFactory faceFactory, DiceFacesSettings diceFacesSettings)
        {
            _faceFactory = faceFactory;
            CreateDiceFaces(diceFacesSettings.DiceFaces.Select(face => face.Value).ToArray());
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
                var diceFaceInstance = _faceFactory.GetFace(diceFacesValues[i]);
                diceFaceInstance.transform.SetParent(FacesRoots[i], worldPositionStays: false);
            }
        }
    }
}