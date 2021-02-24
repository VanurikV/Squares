using Client;
using Leopotam.Ecs;

namespace squares
{
    sealed class S_01_RestartSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private GlobalData _globalData = null;

        private EcsFilter<RestartComponent> _restartFilter = null;
        private EcsFilter<WaitForTochComponent> _waiteFilter = null;

        void IEcsRunSystem.Run()
        {
            if (!_restartFilter.IsEmpty() && !_waiteFilter.IsEmpty())
            {
                // add your run code here.
            }
        }
    }
}