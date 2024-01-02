using UnityEngine;

namespace Upgrades
{
    [CreateAssetMenu(fileName = "SpellsProvider", menuName = "ScriptableObjects/SpellsProvider")]
    public class SpellsProvider : ScriptableObject
    {
        [field: SerializeField] public Spell[] Spells { get; set; }
    }
}