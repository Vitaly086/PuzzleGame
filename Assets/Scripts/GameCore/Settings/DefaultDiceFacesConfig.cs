using GameCore.Dice;
using GameCore.DiceDatas;
using UnityEngine;

namespace GameCore.Settings
{
    [CreateAssetMenu(fileName = "DefaultDiceFacesConfig", menuName = "Dice/DefaultDiceFacesConfig")]

    public class DefaultDiceFacesConfig : ScriptableObject
    {
        [field: SerializeField]
        public DicePrefabType DicePrefabType { get; set; }

        [field: SerializeField]
        public DiceFace[] DiceFaces { get; private set; } = new DiceFace[GlobalConstants.DICE_FACE_COUNT];
    }
}