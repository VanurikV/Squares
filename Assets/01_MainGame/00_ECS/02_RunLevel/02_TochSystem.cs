using Leopotam.Ecs;
using UnityEngine;

namespace squares
{
    sealed class S_02_TochSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        //private GlobalData _globalData = null;

        private EcsFilter<WaitForTochComponent> _touchFilter = null;

        void IEcsRunSystem.Run()
        {
            if (!_touchFilter.IsEmpty())
            {
                if (Input.GetMouseButtonDown(0))
                {
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out var hitInfo)  && hitInfo.collider.tag == "Square")
                    {
                        _touchFilter.GetEntity(0).Destroy();

                        EcsEntity ent = _world.NewEntity();
                        ent.Get<CheckMoveComponent>().obj=hitInfo.transform.gameObject;
                    }
                }
            }


        }
    }
}