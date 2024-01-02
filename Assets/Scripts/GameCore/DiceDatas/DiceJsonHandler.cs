using System.Collections.Generic;
using GameCore.Settings;
using Newtonsoft.Json;

namespace GameCore.DiceDatas
{
    public static class DiceJsonHandler
    {
        public static string SerializeDices(List<DiceFacesConfig> dices)
        {
            return JsonConvert.SerializeObject(dices);
        }

        public static List<DiceFacesConfig> DeserializeDices(string json)
        {
            return JsonConvert.DeserializeObject<List<DiceFacesConfig>>(json);
        }
    }
}