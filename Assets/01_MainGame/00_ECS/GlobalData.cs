using System.Collections;
using System.Collections.Generic;
using squares;
using UnityEngine;

public class GlobalData
{
    /// <summary>Все префабы</summary>
    public GameObject[] PrefabList;
    
    /// <summary>Данные о всех уровнях в игре</summary>
    public LevelCell[][,] AllLevels = new LevelCell[Const.MaxLevel][,];

    /// <summary>Список ходов для отмены </summary>
    public Stack<List<UndoItem>> UndList =new Stack<List<UndoItem>>();

    /// <summary>Текущее игровое поле</summary>
    public Cell[,] GameField;

    /// <summary>Номер текущего уровня</summary>
    public int CurrentLevel;

    public SoundFxScript SoundFxScript;
    public SoundPlayScript SoundPlayScript;


    //Конструктор
    public GlobalData()
    {
        for (int i = 0; i < Const.MaxLevel; i++)
        {
            AllLevels[i] = new LevelCell[Const.MapSize, Const.MapSize];
        }

        
    }
}
