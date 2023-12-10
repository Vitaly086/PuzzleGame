using Score;
using UnityEngine;

/// <summary>
/// Третий кран магазина - спеллы
/// </summary>
public class SpellsPresenter : MonoBehaviour
{
    [SerializeField] private SpellsProvider _spellsProvider;
    [SerializeField] private SpellButtonPresenter _spellButtonButtonPrefab;
    [SerializeField] private Transform _root;

    public void Initialize(FaceUpgradeService faceUpgradeService, IScoreService scoreService,
        int faceIndex)
    {
        var spells = _spellsProvider.Spells;
        foreach (var spell in spells)
        {
            var spellButton = Instantiate(_spellButtonButtonPrefab, _root);
            spellButton.Initialize(faceUpgradeService, scoreService, faceIndex, spell);
        }
    }
}