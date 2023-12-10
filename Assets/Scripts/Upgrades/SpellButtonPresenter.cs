using Score;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class SpellButtonPresenter : MonoBehaviour
{
    [SerializeField] private Button _upgradeCharacteristicButton;
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

        _upgradeCharacteristicButton
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
            .SubscribeToInteractable(_upgradeCharacteristicButton)
            .AddTo(this);
    }

    private bool HasEnoughMoneyToUpgrade(int upgradeCost)
    {
        return _scoreService.HasEnoughScore(upgradeCost);
    }
}