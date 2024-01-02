using System;
using GameCore.Dice;
using GameCore.DiceDatas;

namespace GameCore.Settings
{
    /// <summary>
    /// Грани одного кубика
    /// </summary>
    [Serializable]
    public class DiceFacesConfig
    {
        public DicePrefabType DicePrefabType { get; set; }

        public DiceFace[] DiceFaces { get; set; }

        public int this[int index]
        {
            get => DiceFaces[index].Value;
            set => DiceFaces[index].Value = value;
        }
        
        public void AddValue(int index, int value)
        {
            this[index] += value;
        }
    }
}