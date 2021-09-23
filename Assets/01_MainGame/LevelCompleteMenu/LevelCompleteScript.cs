using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace squares
{
    public class LevelCompleteScript : MonoBehaviour
    {
        public EcsStartup esc;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.transform.gameObject.SetActive(false);

                EcsEntity ent1 = esc._world.NewEntity();
                ent1.Get<RestartComponent>();
            }
        }
    }
}
