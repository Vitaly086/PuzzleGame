using System;
using GameCore.Dice;
using UnityEngine;

/// <summary>
/// Второе окно магазина - в котором все грани одного кубика
/// </summary>
public class DiceFacesPresenter : MonoBehaviour
{
    public event Action<DiceFacesSettings, int> FaceButtonClicked;
    [SerializeField] private FaceButtonPresenter[] facesPresenters;
    private DiceFacesSettings _diceFacesSettings;
    
    public void Initialize(DiceFacesSettings diceFacesSettings)
    {
        _diceFacesSettings = diceFacesSettings;
        var faces = diceFacesSettings.DiceFaces;
        
        for (var i = 0; i < facesPresenters.Length; i++)
        {
            var facePresenter = facesPresenters[i];
            facePresenter.Initialize(faces[i].Value);
            
            facePresenter.Button.onClick.AddListener(() => OnFaceButtonClicked(i));
        }
    }

    private void OnFaceButtonClicked(int index)
    {
        FaceButtonClicked?.Invoke(_diceFacesSettings, index);
    }
}