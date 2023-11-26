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
    public string Name => _name;

    [SerializeField]
    private int _id;
    
    [SerializeField]
    private string _name;
}