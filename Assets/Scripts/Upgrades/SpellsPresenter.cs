using System.Collections.Generic;
using GameServices;
using UnityEngine;

namespace Upgrades
{
    /// <summary>
    /// Третий кран магазина - спеллы
    /// </summary>
    public class SpellsPresenter : MonoBehaviour
    {
        [SerializeField] private SpellsProvider _spellsProvider;
        [SerializeField] private SpellButtonPresenter _spellButtonButtonPrefab;
        [SerializeField] private Transform _root;
        private List<SpellButtonPresenter> _spellButtonPresenters = new();

        public void Initialize(FaceUpgradeService faceUpgradeService, IScoreService scoreService,
            int faceIndex)
        {
            var spells = _spellsProvider.Spells;
            foreach (var spell in spells)
            {
                var spellButton = Instantiate(_spellButtonButtonPrefab, _root);
                spellButton.Initialize(faceUpgradeService, scoreService, faceIndex, spell);
                _spellButtonPresenters.Add(spellButton);
            }
        }

        private void OnDisable()
        {
            foreach (var spellButtonPresenter in _spellButtonPresenters)
            {
                Destroy(spellButtonPresenter.gameObject);
            }
        
            _spellButtonPresenters.Clear();
        }
    }
}