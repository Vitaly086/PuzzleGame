using GameServices;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Upgrades
{
    public class SpellButtonPresenter : MonoBehaviour
    {
        [SerializeField] private Button _upgradeFaceButton;
        [SerializeField] private TextMeshProUGUI _valueLabel;
        [SerializeField] private TextMeshProUGUI _costLabel;

        private IScoreService _scoreService;
        private int _faceIndex;
        private Spell _spell;

        public void Initialize(FaceUpgradeService faceUpgradeService, IScoreService scoreService,
            int faceIndex, Spell spell)
        {
            _valueLabel.text = $"+ {spell.Value}";
            _costLabel.text = spell.Cost.ToString();
        
            _scoreService = scoreService;
            _faceIndex = faceIndex;
            _spell = spell;

            _upgradeFaceButton
                .OnClickAsObservable()
                .Subscribe(_ => faceUpgradeService.UpgradeFace(_faceIndex, _spell))
                .AddTo(this);

            var upgradeCost = spell.Cost;
            var hasEnoughMoney = scoreService.Score
                .Select(score => HasEnoughMoneyToUpgrade(upgradeCost))
                .DistinctUntilChanged() // Опционально, предотвращает множественные одинаковые уведомления
                .Replay(1)
                .RefCount();

            hasEnoughMoney
                .SubscribeToInteractable(_upgradeFaceButton)
                .AddTo(this);
        }

        private bool HasEnoughMoneyToUpgrade(int upgradeCost)
        {
            return _scoreService.HasEnoughScore(upgradeCost);
        }
    }
}