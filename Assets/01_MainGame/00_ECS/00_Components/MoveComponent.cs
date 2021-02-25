using System.Collections.Generic;
using UnityEngine;

namespace squares
{
    struct MoveComponent
    {
        /// <summary>направление движения </summary>
        public Direction Direction;
        /// <summary>список объектов </summary>
        public List<GameObject> SquaresToMove;
        /// <summary>конечная точка </summary>
        public List<Vector3> DstPos;
        /// <summary>начальная точка на карте </summary>
        public List<Vector2Int> SrcPosInts;
        /// <summary>конечная точка на карте</summary>
        public List<Vector2Int> DstPosInts;

    }
}