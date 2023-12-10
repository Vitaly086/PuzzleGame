using System;
using System.Collections.Generic;
using GameCore.Dice;
using UnityEngine;

[Serializable] // Потом убрать
public class HandWithDices
{
    // TODO: Надо хранить кубики в префсах и на старте сетить сюда кубики с актуальными характеристиками
    [SerializeField] private List<DiceFacesSettings> Dices;

    public List<DiceFacesSettings> GetDices()
    {
        return Dices;
    }
        
    public void AddDice()
    {
        // TODO: Добавляем 1 кубик - для каждого кубика сетятся дефолтные настройки
    }
}