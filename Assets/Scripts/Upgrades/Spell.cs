using UnityEngine;

[CreateAssetMenu(fileName = "Spell", menuName = "ScriptableObjects/Spell")]
public class Spell : ScriptableObject
{
    [field: SerializeField] public int Value { get; set; }
    [field: SerializeField] public int Cost { get; set; }
}