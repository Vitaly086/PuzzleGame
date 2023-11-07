using UnityEngine;

namespace GameCore.Dice
{
    [CreateAssetMenu(fileName = "DicePhysicSettings", menuName = "Dice/DicePhysicSettings")]
    public class DicePhysicSettings : ScriptableObject
    {
      [field: SerializeField, Min(1)]  public float Speed { get; private set; }
      [field: SerializeField, Min(1)]  public float Mass  { get; private set; }
      [field: SerializeField, Range(0, 1)]  public float Bounciness { get; private set; }
    }
}