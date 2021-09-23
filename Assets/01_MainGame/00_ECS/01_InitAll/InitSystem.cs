using Leopotam.Ecs;
using System;
using UnityEngine;

namespace squares
{
    sealed partial class InitSystem : IEcsInitSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private GlobalData _globalData = null;

        public void Init()
        {
            LoladAllLevels();

            LoadPrefab();

            LoadLevelData();

            InitSound();

            EcsEntity ent = _world.NewEntity();
            ent.Get<RestartComponent>();

            EcsEntity ent2 = _world.NewEntity();
            ent2.Get<WaitForTochComponent>();
        }


        private void LoadLevelData()
        {
            if (PlayerPrefs.HasKey(PPString.CurrentLevel.ToString()))
            {
                _globalData.CurrentLevel = PlayerPrefs.GetInt(PPString.CurrentLevel.ToString());
            }
            else
            {
                PlayerPrefs.SetInt(PPString.CurrentLevel.ToString(), 0);
                PlayerPrefs.Save();
                _globalData.CurrentLevel = 0;
            }
        }


        private void InitSound()
        {

            _globalData.SoundFxScript = GameObject.Find("SoundFx").GetComponent<SoundFxScript>();
            _globalData.SoundPlayScript = GameObject.Find("SoundPlay").GetComponent<SoundPlayScript>();

            float vol = PlayerPrefs.GetFloat(PPString.SoundPlayVol.ToString());
            float fx = PlayerPrefs.GetFloat(PPString.SoundFxVol.ToString());


            GameObject.Find("SoundFx").GetComponent<AudioSource>().volume = fx;
            GameObject.Find("SoundPlay").GetComponent<AudioSource>().volume = vol;

        }

    }
}