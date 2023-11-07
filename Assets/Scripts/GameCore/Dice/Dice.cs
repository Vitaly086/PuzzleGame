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
        [SerializeField]
        private Transform[] _facesRoot = new Transform[GlobalConstants.DICE_FACE_COUNT];
        private DiceFaceFactory _diceFaceFactory;

        [Inject]
        private void Construct(DiceFaceFactory diceFaceFactory, DiceFacesSettings diceFacesSettings)
        {
            _diceFaceFactory = diceFaceFactory;
            CreateDiceFaces(diceFacesSettings.DiceFaces.Select(face => face.Value).ToArray());
        }

        private void CreateDiceFaces(int[] diceFacesValues)
        {
            if (_facesRoot.Length != diceFacesValues.Length)
            {
                throw new InvalidOperationException(
                    "The number of dice face values does not match the number of face roots.");
            }

            for (int i = 0; i < _facesRoot.Length; i++)
            {
                var diceFaceInstance = _diceFaceFactory.GetFace(diceFacesValues[i]);
                diceFaceInstance.transform.SetParent(_facesRoot[i], worldPositionStays: false);
            }
        }
    }
}