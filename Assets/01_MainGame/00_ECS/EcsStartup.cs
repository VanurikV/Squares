using Leopotam.Ecs;
using UnityEngine;

namespace squares
{
    public class EcsStartup : MonoBehaviour
    {
        public EcsWorld _world;
        public EcsSystems _systems;
        public GlobalData _globalData;

        void Start()
        {
            // void can be switched to IEnumerator for support coroutines.
            _globalData = new GlobalData();

            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            _systems
                // register your systems here, for example:
                // .Add (new TestSystem1 ())
                // .Add (new TestSystem2 ())
                .Add(new InitSystem())

                .Add(new S_01_RestartSystem())
                .Add(new S_02_TochSystem())
                .Add(new S_03_CheckMoveSystem())
                .Add(new S_04_MoveSystem())

                .Add(new S_05_UndoSystem())

                .Add(new S_06_CheckFinishSystem())
                .Add(new S_07_FinishSystem())


                .Add(new S_10_SoundSystem())

                //.Add(new ExitSystem())


                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()
                //.OneFrame<RestartComponent>()

                .OneFrame<SoundFxComponent>()


                // inject service instances here (order doesn't important), for example:
                // .Inject (new CameraService ())
                // .Inject (new NavMeshSupport ())
                .Inject(_globalData)

                .Init();
        }

        void Update()
        {
            _systems?.Run();
        }

        void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}