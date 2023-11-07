using System;
using System.Linq;
using DefaultNamespace;
using Zenject;
using UnityEngine;

namespace GameCore.Dice
{
    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
    public class Dice : MonoBehaviour
    {
        [field: SerializeField] 
        public Transform[] FacesRoot { get; set; }

        [field: SerializeField] 
        public DiceFacesSettings DiceFacesSettings { get; set; }
        private DiceFaceFactory _diceFaceFactory;

        [Inject]
        private void Construct(DiceFaceFactory diceFaceFactory, DiceFacesSettings diceFacesSettings)
        {
            _diceFaceFactory = diceFaceFactory;
            CreateDiceFaces(diceFacesSettings.DiceFaces.Select(face => face.Value).ToArray());
        }

        private void CreateDiceFaces(int[] diceFacesValues)
        {
            if (FacesRoot.Length != diceFacesValues.Length)
            {
                throw new InvalidOperationException(
                    "The number of dice face values does not match the number of face roots.");
            }

            for (int i = 0; i < FacesRoot.Length; i++)
            {
                var diceFaceInstance = _diceFaceFactory.GetFace(diceFacesValues[i]);
                diceFaceInstance.transform.SetParent(FacesRoot[i], worldPositionStays: false);
            }
        }
    }
}