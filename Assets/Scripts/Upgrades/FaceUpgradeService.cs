using GameCore.Settings;
using GameServices;

namespace Upgrades
{
    /// <summary>
    /// Класс, через который апгрейдятся характеристики
    /// </summary>
    public class FaceUpgradeService
    {
        private readonly IScoreService _scoreService;
        private DiceFacesConfig _diceFacesConfig;
        
        public FaceUpgradeService(DiceFacesConfig diceFacesConfig, IScoreService scoreService)
        {
            _scoreService = scoreService;
            _diceFacesConfig = diceFacesConfig;
        }

        public void UpgradeFace(int faceIndex, Spell spell)
        {
            var upgradeCost = spell.Cost;
            if (!CanUpgrade(upgradeCost))
            {
                return;
            }

            _scoreService.Pay(upgradeCost);
            _diceFacesConfig.AddValue(faceIndex, spell.Value);
        }

        private bool CanUpgrade(int cost)
        {
            return _scoreService.HasEnoughScore(cost);
        }
    }
}