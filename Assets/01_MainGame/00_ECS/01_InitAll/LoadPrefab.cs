using System;
using UnityEngine;

namespace squares
{
    sealed partial class InitSystem
    {
        private void LoadPrefab()
        {
            _globalData.PrefabList = new GameObject[Enum.GetNames(typeof(GamePrefab)).Length];

            _globalData.PrefabList[(int)GamePrefab.Squares] = Resources.Load("Square") as GameObject;
            _globalData.PrefabList[(int)GamePrefab.Finish] = Resources.Load("Finish") as GameObject;
            _globalData.PrefabList[(int)GamePrefab.DirChange] = Resources.Load("DirChange") as GameObject;
        }
    }
}