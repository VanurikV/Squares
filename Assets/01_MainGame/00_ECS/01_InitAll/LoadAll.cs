using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace squares
{
    sealed partial class InitSystem
    {
        private void LoladAllLevels()
        {

            for (int i = 0; i < Const.MaxLevel; i++)
            {
                TextAsset levelData = Resources.Load<TextAsset>("LevelMap/Level" + i.ToString("D2"));
                Parse(levelData.text, i);
            }
        }

        private void Parse(string levelData, int level)
        {
            List<string> Allline = levelData.Replace('\r', ' ').Split('\n').Select(x => x.Trim()).ToList();

            for (int y = 0; y < Const.MapSize; y++)
            {
                List<string> lineSq = Allline[y].Split(',').ToList();
                List<string> lineOb = Allline[y + Const.MapSize + 2].Split(',').ToList();

                for (int x = 0; x < Const.MapSize; x++)
                {
                    _globalData.AllLevels[level][x, y] = new LevelCell();

                    if (x == 0 & y == 0)
                    {
                        _globalData.AllLevels[level][x, y].Squares = "";
                        _globalData.AllLevels[level][x, y].Obj = "";
                        continue;
                    }

                    _globalData.AllLevels[level][x, y].Squares = lineSq[x].Trim();
                    _globalData.AllLevels[level][x, y].Obj = lineOb[x].Trim();
                }
            }
        }
    }
}