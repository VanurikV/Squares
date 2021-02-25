using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using squares;
using Stone;
using UnityEngine;

public class RestartButtonScript : MonoBehaviour
{

    public EcsStartup esc;

    public void onRestart()
    {
        EcsEntity ent = esc._world.NewEntity();
        ent.Get<RestartComponent>();
    }

    public void onUndo()
    {
        EcsEntity ent = esc._world.NewEntity();
        ent.Get<UndoComponent>();
    }

}
