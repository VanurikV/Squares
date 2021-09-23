using Leopotam.Ecs;
using UnityEngine;

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

                SaveGameProggress();

                EcsEntity ent3 = _world.NewEntity();
                SoundFxComponent s = new SoundFxComponent();
                s.Fx = SoundFx.LevelComplete;
                ent3.Get<SoundFxComponent>() = s;

                GameObject.FindObjectOfType<LevelCompleteScript>(true).gameObject.SetActive(true);

            }
        }

        public void SaveGameProggress()
        {
            _globalData.CurrentLevel++;

            if (_globalData.CurrentLevel >= Const.MaxLevel)
                _globalData.CurrentLevel = 0;

            PlayerPrefs.SetInt(PPString.CurrentLevel.ToString(), _globalData.CurrentLevel);
            PlayerPrefs.Save();

            int MaxLevel = PlayerPrefs.GetInt(PPString.MaxCompleteLevel.ToString());
            if (MaxLevel < _globalData.CurrentLevel)
            {

                PlayerPrefs.SetInt(PPString.MaxCompleteLevel.ToString(), _globalData.CurrentLevel);
                PlayerPrefs.Save();
            }

        }


    }
}