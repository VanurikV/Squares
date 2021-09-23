using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace squares
{
    sealed class S_04_MoveSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private GlobalData _globalData = null;

        private EcsFilter<MoveComponent> _moveFilter = null;

        void IEcsRunSystem.Run()
        {
            if (!_moveFilter.IsEmpty())
            {
                List<GameObject> squaresToMove = _moveFilter.Get1(0).SquaresToMove;
                List<Vector3> dstPos = _moveFilter.Get1(0).DstPos;
                Direction moveDirection = _moveFilter.Get1(0).Direction;

                Vector2Int moveDirectionInt = Const.DirToVecI(moveDirection);
                Vector3 moveDirectionF = Const.DirToVecF(moveDirection);

                
                foreach (GameObject o in _moveFilter.Get1(0).SquaresToMove)
                {
                    float d = Const.MoveSpeed * Time.deltaTime;
                    if (d > 9) d = 9;
                    o.transform.position += moveDirectionF * d;
                }

                
                for (int i = 0; i < _moveFilter.Get1(0).SquaresToMove.Count; i++)
                {
                    if (Vector3.Distance(squaresToMove[i].transform.position, dstPos[i]) < 10)
                    {
                
                        squaresToMove[i].transform.position = dstPos[i];

                
                        if (_globalData.GameField[_moveFilter.Get1(0).DstPosInts[i].x,
                            _moveFilter.Get1(0).DstPosInts[i].y].ChangeDirection != Direction.None)
                        {
                            squaresToMove[i].GetComponent<SquareScript>().SetDirection(_globalData.GameField[_moveFilter.Get1(0).DstPosInts[i].x, _moveFilter.Get1(0).DstPosInts[i].y].ChangeDirection);
                        }

                
                        GameObject o = _globalData.GameField[_moveFilter.Get1(0).SrcPosInts[i].x, _moveFilter.Get1(0).SrcPosInts[i].y].Obj;
                        _globalData.GameField[_moveFilter.Get1(0).SrcPosInts[i].x, _moveFilter.Get1(0).SrcPosInts[i].y].Obj = null;
                        _globalData.GameField[_moveFilter.Get1(0).DstPosInts[i].x, _moveFilter.Get1(0).DstPosInts[i].y].Obj = o;

                        _moveFilter.Get1(0).SquaresToMove.RemoveAt(i);
                        _moveFilter.Get1(0).DstPos.RemoveAt(i);
                        _moveFilter.Get1(0).SrcPosInts.RemoveAt(i);
                        _moveFilter.Get1(0).DstPosInts.RemoveAt(i);
                        i--;
                    }


                }


                if (_moveFilter.Get1(0).SquaresToMove.Count == 0)
                {
                    _moveFilter.GetEntity(0).Destroy();

                    EcsEntity ent1 = _world.NewEntity();
                    ent1.Get<CheckFinishComponent>();
                }
            }

        }
    }
}