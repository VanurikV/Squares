using Leopotam.Ecs;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace squares
{
    sealed class S_01_RestartSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private GlobalData _globalData = null;

        private EcsFilter<RestartComponent> _restartFilter = null;
        private EcsFilter<WaitForTochComponent> _waiteFilter = null;
        private EcsFilter<CheckMoveComponent> _checkFilter = null;
        private EcsFilter<MoveComponent> _moveFilter = null;

        void IEcsRunSystem.Run()
        {
            if (!_restartFilter.IsEmpty())
            {
                ClearFilter();
                ClearData();
                DeleteObject();
                InitGameField();
                InitLevelString();
            }
        }

        private void InitGameField()
        {
            _globalData.GameField = new Cell[Const.MapSize, Const.MapSize];
            for (int y = 0; y < Const.MapSize; y++)
            {
                for (int x = 0; x < Const.MapSize; x++)
                {
                    _globalData.GameField[x, y] = new Cell();
                    if (_globalData.AllLevels[_globalData.CurrentLevel][x, y].Squares != "")
                    {

                        switch (_globalData.AllLevels[_globalData.CurrentLevel][x, y].Squares[0])
                        {
                            case 'R':
                            case 'B':
                            case 'G':
                            case 'P':

                                GameObject o = GameObject.Instantiate(_globalData.PrefabList[(int)GamePrefab.Squares]);
                                o.GetComponent<SquareScript>()
                                    .Init(_globalData.AllLevels[_globalData.CurrentLevel][x, y].Squares);
                                o.transform.position = new Vector3(Const.CellSizePx * x, -Const.CellSizePx * y);
                                o.name = "x:=" + x + " y:=" + y;

                                _globalData.GameField[x, y].Obj = o;

                                break;
                        }
                    }

                    if (_globalData.AllLevels[_globalData.CurrentLevel][x, y].Obj != "")
                    {
                        //Instantiate Finish
                        if (_globalData.AllLevels[_globalData.CurrentLevel][x, y].Obj[0] == 'F')
                        {
                            GameObject o = GameObject.Instantiate(_globalData.PrefabList[(int)GamePrefab.Finish]);
                            o.transform.position = new Vector3((Const.CellSizePx * x), (-Const.CellSizePx * y));

                            o.GetComponent<FinishScript>()
                                .Init(_globalData.AllLevels[_globalData.CurrentLevel][x, y].Obj);
                            _globalData.GameField[x, y].FinishColor = o.GetComponent<FinishScript>().GetColor();
                        }

                        //Instantiate DirChange
                        if (_globalData.AllLevels[_globalData.CurrentLevel][x, y].Obj[0] == 'D')
                        {
                            if (_globalData.GameField[x, y] == null) _globalData.GameField[x, y] = new Cell();

                            GameObject o = GameObject.Instantiate(_globalData.PrefabList[(int)GamePrefab.DirChange]);
                            o.transform.position = new Vector3(Const.CellSizePx * x+75, -Const.CellSizePx * y-75);

                            o.GetComponent<DirChangeScript>().Init(_globalData.AllLevels[_globalData.CurrentLevel][x, y].Obj);

                            _globalData.GameField[x, y].ChangeDirection = o.GetComponent<DirChangeScript>().GetDirection();

                        }

                    }

                }
            }

            EcsEntity ent = _world.NewEntity();
            ent.Get<WaitForTochComponent>();

        }

        private void ClearFilter()
        {
            foreach (int i in _restartFilter)
            {
                _restartFilter.GetEntity(i).Destroy();
            }

            foreach (int i in _waiteFilter)
            {
                _waiteFilter.GetEntity(i).Destroy();
            }

            foreach (int i in _checkFilter)
            {
                _checkFilter.GetEntity(i).Destroy();
            }

            foreach (int i in _moveFilter)
            {
                _moveFilter.GetEntity(i).Destroy();
            }
        }

        private void ClearData()
        {
            _globalData.UndList=new Stack<List<UndoItem>>();
            _globalData.GameField = new Cell[Const.MapSize, Const.MapSize];
        }

        private void DeleteObject()
        {
            List<GameObject> oList= GameObject.FindGameObjectsWithTag("Square").ToList();
            oList.AddRange(GameObject.FindGameObjectsWithTag("Finish"));
            oList.AddRange(GameObject.FindGameObjectsWithTag("DirChange"));

            foreach (GameObject o in oList)
            {
                GameObject.Destroy(o);
            }

        }

        private void InitLevelString()
        {
            GameObject.Find("LevelString").GetComponent<LevelScript>().SetLevel();
        }


    }
}