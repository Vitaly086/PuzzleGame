using System;
using UnityEngine;
using Zenject;

namespace GameCore.Dice
{
    public class PhysicDice : MonoBehaviour
    {
        public event Action Stopped;

        private readonly float _stoppedThreshold = 0.1f;
        private float _timeBelowThreshold;

        private DicePhysicSettings _dicePhysicSettings;
        private Rigidbody _rigidbody;
        private BoxCollider _collider;
        private ITarget _target;
        private DiceFaceFactory _faceFactory;
        private bool _isStopped;

        [Inject]
        private void Construct(DiceFaceFactory faceFactory, DiceFacesSettings diceFacesSettings,
            DicePhysicSettings dicePhysicSettings, ITarget target)
        {
            _dicePhysicSettings = dicePhysicSettings;
            _target = target;

            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<BoxCollider>();

            ApplyPhysicsSettings();
        }

        private void Update()
        {
            if (_isStopped)
            {
                return;
            }

            if (IsFullyStopped())
            {
                _timeBelowThreshold += Time.deltaTime; // Накапливаем время, в течение которого скорость мала
                if (_timeBelowThreshold >= _dicePhysicSettings.StoppedTimeThreshold)
                {
                    Stopped?.Invoke();
                    _isStopped = true;
                }
            }
            else
            {
                _timeBelowThreshold = 0f; // Сбрасываем таймер
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
            AddRandomRotation();

            _isStopped = false;
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

        private bool IsFullyStopped()
        {
            return _rigidbody.velocity.magnitude < _stoppedThreshold &&
                   _rigidbody.angularVelocity.magnitude < _stoppedThreshold;
        }

        private void AddRandomRotation()
        {
           
            var torque = new Vector3(
                UnityEngine.Random.Range(-1f, 1f),
                UnityEngine.Random.Range(-1f, 1f),
                UnityEngine.Random.Range(-1f, 1f)
            ) * _dicePhysicSettings.TorqueMagnitude;

            _rigidbody.AddTorque(torque, ForceMode.VelocityChange);
        }
    }
}