using System;
using System.Collections.Generic;
using GameCore.DiceDatas;
using GameCore.Settings;

namespace GameCore.Dice
{
    public class HandWithDices : IDisposable
    {
        public IReadOnlyList<DiceFacesConfig> Dices => _dices;
        private readonly DiceDataManager _diceDataManager;
        private readonly List<DiceFacesConfig> _dices;

        public HandWithDices(DiceDataManager diceDataManager)
        {
            _diceDataManager = diceDataManager;
            _dices = diceDataManager.DiceFacesConfigs;
        }

        public DiceFacesConfig AddNewDice()
        {
            var newDiceSettings = _diceDataManager.CreateDefaultDiceSettings();
            _dices.Add(newDiceSettings);
            return newDiceSettings;
        }

        public void Dispose()
        {
            _diceDataManager.SaveDices(_dices);
        }
    }
}