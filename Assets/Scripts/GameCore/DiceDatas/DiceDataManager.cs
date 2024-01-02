using System.Collections.Generic;
using GameCore.Dice;
using GameCore.Settings;
using UnityEngine;

namespace GameCore.DiceDatas
{
    public class DiceDataManager
    {
        public List<DiceFacesConfig> DiceFacesConfigs { get; }
        private readonly DefaultDiceFacesConfig _defaultSettings;
        private const string PlayerPrefsKey = "DicesData";

        public DiceDataManager(DefaultDiceFacesConfig defaultSettings)
        {
            _defaultSettings = defaultSettings;
            DiceFacesConfigs = LoadDices();
        }

        public void SaveDices(List<DiceFacesConfig> dices)
        {
            var json = DiceJsonHandler.SerializeDices(dices);
            PlayerPrefs.SetString(PlayerPrefsKey, json);
            PlayerPrefs.Save();
        }


        private List<DiceFacesConfig> LoadDices()
        {
            var json = PlayerPrefs.GetString(PlayerPrefsKey, "[]");
            var dices = DiceJsonHandler.DeserializeDices(json);

            if (dices == null || dices.Count == 0)
            {
                dices = new List<DiceFacesConfig>
                {
                    CreateDefaultDiceSettings()
                };
            }

            return dices;
        }


        public DiceFacesConfig CreateDefaultDiceSettings()
        {
            var clonedFaces = new DiceFace[_defaultSettings.DiceFaces.Length];

            for (int i = 0; i < clonedFaces.Length; i++)
            {
                clonedFaces[i] = new DiceFace { Value = _defaultSettings.DiceFaces[i].Value };
            }

            return new DiceFacesConfig { DiceFaces = clonedFaces, DicePrefabType = _defaultSettings.DicePrefabType};
        }
    }
}