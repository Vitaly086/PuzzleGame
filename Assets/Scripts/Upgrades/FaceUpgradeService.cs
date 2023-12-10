using GameCore.Dice;
using Score;

/// <summary>
/// Класс, через который апгрейдятся характеристики
/// </summary>
public class FaceUpgradeService
{
    private readonly IScoreService _scoreService;
    private DiceFacesSettings _diceFacesSettings;
        
    public FaceUpgradeService(DiceFacesSettings diceFacesSettings, IScoreService scoreService)
    {
        _scoreService = scoreService;
        _diceFacesSettings = diceFacesSettings;
    }

    public void UpgradeFace(int faceIndex, Spell spell)
    {
        var upgradeCost = spell.Cost;
        if (!CanUpgrade(upgradeCost))
        {
            return;
        }

        _scoreService.Pay(upgradeCost);
        _diceFacesSettings.AddValue(faceIndex, spell.Value);
    }

    private bool CanUpgrade(int cost)
    {
        return _scoreService.HasEnoughScore(cost);
    }
}