using Leopotam.Ecs;
using UnityEngine;

namespace squares
{
    sealed class ExitSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;

        void IEcsRunSystem.Run()
        {
            if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Menu))
            {
                Application.Quit();
            }
        }
    }
}