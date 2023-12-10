using System;
using System.Collections.Generic;
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
    private List<FaceButtonPresenter> _faceButtonPresenters = new();
    
    public void Initialize(DiceFacesSettings diceFacesSettings)
    {
        _diceFacesSettings = diceFacesSettings;
        SetFacesValues(diceFacesSettings);
    }

    private void SetFacesValues(DiceFacesSettings diceFacesSettings)
    {
        var faces = diceFacesSettings.DiceFaces;

        for (var i = 0; i < facesPresenters.Length; i++)
        {
            var facePresenter = facesPresenters[i];
            facePresenter.Initialize(faces[i].Value);

            _faceButtonPresenters.Add(facePresenter);
            
            var index = i;
            facePresenter.Button.onClick.AddListener(() => OnFaceButtonClicked(index));
        }
        
        Debug.LogError("Подписка на кнопки граней");
    }

    private void OnFaceButtonClicked(int index)
    {
        FaceButtonClicked?.Invoke(_diceFacesSettings, index);
    }

    private void OnDisable()
    {
        for (var i = 0; i < _faceButtonPresenters.Count; i++)
        {
            var facePresenter = _faceButtonPresenters[i];
            var index = i;
            facePresenter.Button.onClick.RemoveListener(() => OnFaceButtonClicked(index));
        }
        
        Debug.LogError("Отписка от кнопки граней");
    }
}