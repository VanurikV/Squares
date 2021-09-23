using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace squares
{
    sealed class S_03_CheckMoveSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private GlobalData _globalData = null;

        private EcsFilter<CheckMoveComponent> _checkFilter = null;

        void IEcsRunSystem.Run()
        {
            if (!_checkFilter.IsEmpty())
            {
                
                GameObject touchSquare = _checkFilter.Get1(0).obj;
                Direction moveDirection = touchSquare.GetComponent<SquareScript>().SquareDirection;
                Vector2Int touchPos = new Vector2Int((int)touchSquare.transform.position.x / Const.CellSizePx, (int)touchSquare.transform.position.y / -Const.CellSizePx);
                Vector2Int moveDirectionInt = Const.DirToVecI(moveDirection);

                
                _checkFilter.GetEntity(0).Destroy();

                
                if (!CheckMove(touchPos, moveDirectionInt))
                {
                    
                    EcsEntity ent = _world.NewEntity();
                    ent.Get<WaitForTochComponent>();

                    EcsEntity ent4 = _world.NewEntity();
                    SoundFxComponent ss = new SoundFxComponent();
                    ss.Fx = SoundFx.SquareMoveError;
                    ent4.Get<SoundFxComponent>() = ss;

                    return;
                }

                
                List<GameObject> SquaresToMove = new List<GameObject>();
                
                SquaresToMove.Add(_globalData.GameField[touchPos.x, touchPos.y].Obj);

                
                Vector2Int npos = touchPos;
                do
                {
                    npos = npos + moveDirectionInt;
                    if (npos.x < 0 || npos.x >= Const.MapSize || npos.y < 0 || npos.y >= Const.MapSize) break;
                    if (_globalData.GameField[npos.x, npos.y].Obj is null) break;

                    SquaresToMove.Add(_globalData.GameField[npos.x, npos.y].Obj);

                } while (true);

                
                SquaresToMove.Reverse();

                SaveUndo();

                
                EcsEntity ent1 = _world.NewEntity();
                ent1.Get<MoveComponent>().SquaresToMove=SquaresToMove;
                ent1.Get<MoveComponent>().Direction = moveDirection;

                Vector3 moveDirectionF = Const.DirToVecF(moveDirection);

                List<Vector3> dstPos = new List<Vector3>();
                List<Vector2Int> srcPosInt=new List<Vector2Int>();
                List<Vector2Int> dstPosInt=new List<Vector2Int>();

                foreach (GameObject o in SquaresToMove)
                {
                    Vector3 dst = o.transform.position + moveDirectionF * Const.CellSizePx;
                    dstPos.Add(dst);
                    Vector2Int di=new Vector2Int((int)dst.x/Const.CellSizePx,(int)dst.y/-Const.CellSizePx);
                    dstPosInt.Add(di);
                    Vector2Int si=new Vector2Int((int)o.transform.position.x / Const.CellSizePx, (int)o.transform.position.y / -Const.CellSizePx);
                    srcPosInt.Add(si);
                }

                ent1.Get<MoveComponent>().DstPos = dstPos;
                ent1.Get<MoveComponent>().SrcPosInts = srcPosInt;
                ent1.Get<MoveComponent>().DstPosInts = dstPosInt;


                EcsEntity ent3 = _world.NewEntity();
                SoundFxComponent s =new SoundFxComponent();
                s.Fx = SoundFx.SquareMove;
                ent3.Get<SoundFxComponent>() = s;

            }
        }

        
        private bool CheckMove(Vector2Int pos, Vector2Int dir)
        {
            Vector2Int npos = pos;
            do
            {
                npos = npos + dir;
                if (npos.x < 0 || npos.x >= Const.MapSize || npos.y < 0 || npos.y >= Const.MapSize) return false;
                if (_globalData.GameField[npos.x, npos.y].Obj is null) return true;
            } while (true);
        }

        
        private void SaveUndo()
        {
            List<UndoItem> undo=new List<UndoItem>();

            foreach (Cell cell in _globalData.GameField)
            {
                if (!(cell.Obj is null))
                {
                    UndoItem undoItem = new UndoItem();
                    SquareScript sq = cell.Obj.GetComponent<SquareScript>();

                    undoItem.SquareColor = sq.SquareColor;
                    undoItem.SquareDirection = sq.SquareDirection;
                    undoItem.xPos = (int)cell.Obj.transform.position.x / Const.CellSizePx;
                    undoItem.yPos = (int)cell.Obj.transform.position.y / Const.CellSizePx;

                    undo.Add(undoItem);
                }
            }
            _globalData.UndList.Push(undo);
        }


    }
}