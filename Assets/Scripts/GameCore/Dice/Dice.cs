using Zenject;
using UnityEngine;

namespace GameCore.Dice
{
    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
    public class Dice : MonoBehaviour
    {
        private DiceSettings _diceSettings;
        private Rigidbody _rigidbody;
        private BoxCollider _collider;

        [Inject]
        public void Construct(DiceSettings diceSettings)
        {
            _diceSettings = diceSettings;

            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<BoxCollider>();
            ApplySettings();
        }


        private void ApplySettings()
        {
            if (_diceSettings != null)
            {
                _rigidbody.mass = _diceSettings.Mass;
                _rigidbody.drag = _diceSettings.Speed;

                var diceMaterial = new PhysicMaterial
                {
                    bounciness = _diceSettings.Bounciness,
                };
                _collider.material = diceMaterial;
            }
        }
    }
}