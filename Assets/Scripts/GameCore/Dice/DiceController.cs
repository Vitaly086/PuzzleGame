using System;
using DefaultNamespace;
using Zenject;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameCore.Dice
{
    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
    public class DiceController : MonoBehaviour
    {
        [SerializeField]
        private Transform[] _facesRoot = new Transform[GlobalConstants.DICE_FACE_COUNT];
        private readonly DiceFace[] _diceFaces = new DiceFace[GlobalConstants.DICE_FACE_COUNT];

        private DicePhysicSettings _dicePhysicSettings;
        private Rigidbody _rigidbody;
        private BoxCollider _collider;
        private ITarget _target;
        private DiceFaceFactory _diceFaceFactory;


        [Inject]
        private void Construct(DiceFaceFactory diceFaceFactory, DiceFacesSettings diceFacesSettings, DicePhysicSettings dicePhysicSettings, ITarget target)
        {
            _diceFaceFactory = diceFaceFactory;
            _dicePhysicSettings = dicePhysicSettings;
            _target = target;

            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<BoxCollider>();

            ApplySettings();
            CreateDiceFaces(diceFacesSettings.DiceFacesValues);
        }

        private void CreateDiceFaces(int[] diceFacesValues)
        {
            if (_facesRoot.Length != diceFacesValues.Length)
            {
                throw new IndexOutOfRangeException("The number of dice face values does not match the number of face roots.");
            }
            
            for (int i = 0; i < _facesRoot.Length; i++)
            {
                var faceRoot = _facesRoot[i];
                //var diceFaceInstance = _diceFaceFactory.GetFace(diceFacesValues[i]);
                var randomValue = Random.Range(1, 100);
                var diceFaceInstance = _diceFaceFactory.GetFace(randomValue);
                var diceFaceTransform = diceFaceInstance.transform;
                diceFaceTransform.position = faceRoot.position;
                diceFaceTransform.rotation = faceRoot.rotation;
                diceFaceTransform.SetParent(faceRoot.parent, worldPositionStays: false);
                _facesRoot[i] = diceFaceTransform; 
                _diceFaces[i] = diceFaceInstance;
                faceRoot.gameObject.SetActive(false);
            }
        }


        public void Push()
        {
            var direction = (_target.Position - transform.position).normalized;
            var forceMagnitude = _dicePhysicSettings.Speed;

            var distanceToTarget = Vector3.Distance(_target.Position, transform.position);
            var force = direction * forceMagnitude * distanceToTarget;

            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(force, ForceMode.Impulse);
        }

        private void ApplySettings()
        {
            if (_dicePhysicSettings != null)
            {
                _rigidbody.mass = _dicePhysicSettings.Mass;

                var diceMaterial = new PhysicMaterial
                {
                    bounciness = _dicePhysicSettings.Bounciness,
                };
                _collider.material = diceMaterial;
            }
        }
    }
}