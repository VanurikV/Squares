using Leopotam.Ecs;

namespace squares
{
    sealed class S_10_SoundSystem : IEcsRunSystem
    {
        private GlobalData _globalData = null;

        private EcsFilter<SoundFxComponent> _FxFilter = null;

        void IEcsRunSystem.Run()
        {
            if (!_FxFilter.IsEmpty())
            {
                //Play Fx
                _globalData.SoundFxScript.PlayFx(_FxFilter.Get1(0).Fx);
            }
        }
    }
}