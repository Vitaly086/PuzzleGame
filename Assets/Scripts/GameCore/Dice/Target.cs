using UnityEngine;

namespace GameCore.Dice
{
    public class Target : MonoBehaviour, ITarget
    {
        public Vector3 Position => GetRandomPosition();

        private Vector3 GetRandomPosition()
        {
            var randomX = Random.Range(-2f, 2f);
            return new Vector3(randomX, transform.position.y, transform.position.z);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 1f);
        }
    }
}