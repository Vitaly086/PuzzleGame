using System;
using System.Collections.Generic;
using GameCore.Dice;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Второе окно магазина - в котором все грани одного кубика
/// </summary>
public class DiceFacesPresenter : MonoBehaviour
{
    public event Action<DiceFacesSettings, int> FaceButtonClicked;
    [SerializeField] private FaceButtonPresenter[] facesPresenters;
    private DiceFacesSettings _diceFacesSettings;
    private List<FaceButtonPresenter> _faceButtonPresenters = new();
    private List<UnityAction> _faceButtonActions = new(); // Список для хранения действий
    
    public void Initialize(DiceFacesSettings diceFacesSettings)
    {
        _diceFacesSettings = diceFacesSettings;
        SetFacesValues(_diceFacesSettings);
    }

    private void OnEnable()
    {
        if (!_diceFacesSettings)
        {
            return;
        }
        
        _faceButtonPresenters.Clear();
        SetFacesValues(_diceFacesSettings);
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
            UnityAction action = () => OnFaceButtonClicked(index);
            facePresenter.Button.onClick.AddListener(action);
            _faceButtonActions.Add(action); // Сохраняем действие
        }
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
            var action = _faceButtonActions[i];
            facePresenter.Button.onClick.RemoveListener(action);
        }
    
        _faceButtonPresenters.Clear();
        _faceButtonActions.Clear(); // Очищаем список действий
    }
}