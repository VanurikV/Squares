using System.Collections.Generic;
using System.Linq;
using Leopotam.Ecs;
using UnityEngine;

namespace squares
{
    sealed class S_05_UndoSystem : IEcsRunSystem
    {
        // auto-injected fields.
        //readonly EcsWorld _world = null;
        private GlobalData _globalData = null;

        private EcsFilter<WaitForTochComponent> _waiteFilter = null;
        private EcsFilter<UndoComponent> _undoFilter = null;

        void IEcsRunSystem.Run()
        {
            if (!_waiteFilter.IsEmpty() && !_undoFilter.IsEmpty())
            {
                foreach (int i in _undoFilter)
                    _undoFilter.GetEntity(i).Destroy();
                if (_globalData.UndList.Count > 0)
                {
                    Clear();

                    foreach (UndoItem undoItem in _globalData.UndList.Pop())
                    {
                        GameObject o = GameObject.Instantiate(_globalData.PrefabList[(int)GamePrefab.Squares]);
                        o.GetComponent<SquareScript>().Init(undoItem.SquareColor,undoItem.SquareDirection );
                        o.transform.position = new Vector3(Const.CellSizePx * undoItem.xPos, Const.CellSizePx * undoItem.yPos);
                        o.name = "UNDO x:=" + undoItem.xPos + " y:=" + undoItem.yPos*-1;

                        _globalData.GameField[undoItem.xPos, -undoItem.yPos].Obj = o;
                    } 
                }
                
            }


        }

        private void Clear()
        {
            List<GameObject> oList = GameObject.FindGameObjectsWithTag("Square").ToList();
            foreach (GameObject o in oList)
                GameObject.Destroy(o);

            foreach (Cell cell in _globalData.GameField)
                cell.Obj = null;
        }
    }
}