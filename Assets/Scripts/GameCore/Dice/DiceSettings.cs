using UnityEngine;

namespace GameCore.Dice
{
    [CreateAssetMenu(fileName = "DiceSettings", menuName = "GameCore/DiceSettings", order = 1)]
    public class DiceSettings : ScriptableObject
    {
      [field: SerializeField]  public float Speed { get; private set; }
      [field: SerializeField]  public float Mass  { get; private set; }
      [field: SerializeField]  public float Bounciness { get; private set; }
    }
}