using Leopotam.Ecs;
using UnityEngine;

namespace squares
{
    sealed class S_06_CheckFinishSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private GlobalData _globalData = null;

        private EcsFilter<CheckFinishComponent> _finishFilter = null;
        void IEcsRunSystem.Run()
        {
            if (!_finishFilter.IsEmpty())
            {
                foreach (int i in _finishFilter)
                    _finishFilter.GetEntity(i).Destroy();

                bool levelComplete = true;
                foreach (Cell cell in _globalData.GameField)
                {
                    if(cell.FinishColor==Color.None) continue;

                    if (cell.Obj == null)
                    {
                        levelComplete = false;
                        break;
                    }

                    if (cell.Obj.GetComponent<SquareScript>().SquareColor != cell.FinishColor)
                    {
                        levelComplete = false;
                        break;
                    }
                }

                if (!levelComplete)
                {
                    EcsEntity ent1 = _world.NewEntity();
                    ent1.Get<WaitForTochComponent>();
                    return;
                }

                EcsEntity ent2 = _world.NewEntity();
                ent2.Get<FinishComponent>();

            }
        }
    }
}