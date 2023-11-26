using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Настройки одного уровня
/// </summary>
[Serializable]
public class LevelSettings 
{
    public int Id => _id;
    public int RollsForUpgrade => _rollsForUpgrade;

    [SerializeField]
    private int _id;
    
    [SerializeField]
    private int _rollsForUpgrade;
}