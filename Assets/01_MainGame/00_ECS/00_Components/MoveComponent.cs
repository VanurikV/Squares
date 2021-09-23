using System.Collections.Generic;
using UnityEngine;

namespace squares
{
    struct MoveComponent
    {
        
        public Direction Direction;
       public List<GameObject> SquaresToMove;
        public List<Vector3> DstPos;
        public List<Vector2Int> SrcPosInts;
        public List<Vector2Int> DstPosInts;

    }
}