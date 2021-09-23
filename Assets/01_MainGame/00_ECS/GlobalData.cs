using System.Collections;
using System.Collections.Generic;
using squares;
using UnityEngine;

public class GlobalData
{
    
    public GameObject[] PrefabList;
    
    public LevelCell[][,] AllLevels = new LevelCell[Const.MaxLevel][,];

    public Stack<List<UndoItem>> UndList =new Stack<List<UndoItem>>();
    
    public Cell[,] GameField;

    
    public int CurrentLevel;

    public SoundFxScript SoundFxScript;
    public SoundPlayScript SoundPlayScript;


    
    public GlobalData()
    {
        for (int i = 0; i < Const.MaxLevel; i++)
        {
            AllLevels[i] = new LevelCell[Const.MapSize, Const.MapSize];
        }
       
    }
}
