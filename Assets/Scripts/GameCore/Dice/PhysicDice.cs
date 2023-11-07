using UnityEngine;
using Zenject;

namespace GameCore.Dice
{
    public class PhysicDice : MonoBehaviour
    {
        private DicePhysicSettings _dicePhysicSettings;
        private Rigidbody _rigidbody;
        private BoxCollider _collider;
        private ITarget _target;
        private DiceFaceFactory _diceFaceFactory;
        
        [Inject]
        private void Construct(DiceFaceFactory diceFaceFactory, DiceFacesSettings diceFacesSettings,
            DicePhysicSettings dicePhysicSettings, ITarget target)
        {
            _dicePhysicSettings = dicePhysicSettings;
            _target = target;

            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<BoxCollider>();

            ApplyPhysicsSettings();
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

        private void ApplyPhysicsSettings()
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