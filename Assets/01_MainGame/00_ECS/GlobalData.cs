using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData
{
    /// <summary>Все префабы</summary>
    public GameObject[] PrefabList;
    
    /// <summary>Данные о всех уровнях в игре</summary>
    public LevelCell[][,] AllLevels = new LevelCell[Const.MaxLevel][,];

    /// <summary>Список ходов для отмены </summary>
    public List<List<UndoItem>> UndList=new List<List<UndoItem>>();

    /// <summary>Текущее игровое поле</summary>
    public Cell[,] GameField;

    /// <summary>Номер текущего уровня</summary>
    public int CurrentLevel;

    //Конструктор
    public GlobalData()
    {
        for (int i = 0; i < Const.MaxLevel; i++)
        {
            AllLevels[i] = new LevelCell[Const.MapSize, Const.MapSize];
        }

        
    }
}
