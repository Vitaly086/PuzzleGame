using UnityEngine;

[CreateAssetMenu(fileName = "SpellsProvider", menuName = "ScriptableObjects/SpellsProvider")]
public class SpellsProvider : ScriptableObject
{
    [field: SerializeField] private Spell[] Spells { get; set; }
}