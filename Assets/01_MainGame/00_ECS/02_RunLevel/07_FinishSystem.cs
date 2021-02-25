using Leopotam.Ecs;

namespace squares
{
    sealed class S_07_FinishSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private GlobalData _globalData = null;

        private EcsFilter<FinishComponent> _finishFilter = null;

        void IEcsRunSystem.Run()
        {
            if (!_finishFilter.IsEmpty())
            {
                foreach (int i in _finishFilter)
                    _finishFilter.GetEntity(i).Destroy();

                _globalData.CurrentLevel++;

                EcsEntity ent1 = _world.NewEntity();
                ent1.Get<RestartComponent>();
                
            }
        }
    }
}