using ME.ECS;
using Project.Features.Apple.Views;
using Unity.Mathematics;
using UnityEngine;

namespace Project.Features {

    using Components; using Modules; using Systems; using Features; using Markers;
    using Apple.Components; using Apple.Modules; using Apple.Systems; using Apple.Markers;
    
    namespace Apple.Components {}
    namespace Apple.Modules {}
    namespace Apple.Systems {}
    namespace Apple.Markers {}
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class AppleFeature : Feature
    {
        [SerializeField] private AppleView appleView;

        [SerializeField] private GlobalEvent collectFoodEvent;
        public ViewId AppleId { get; private set; }

        private Entity apple;

        protected override void OnConstruct()
        {
            AppleId = world.RegisterViewSource(appleView);
            AddSystem<AppleInitSystem>();
            AddSystem<AppleSpawnSystem>();
            AddSystem<AppleCollectSystem>();
        }

        public void OnCollectFood()
        {
            collectFoodEvent.Execute();
        }

        public void ChangeApplePos()
        {
            var pos = apple.GetPosition();

            float3 newPos;
            
            do
            {
                int newPosX = world.GetRandomRange(0, 31);
                int newPosZ = world.GetRandomRange(0, 31);
                newPos = new float3(newPosX, 0, newPosZ);   
            } while ((int)pos.x == (int)newPos.x && (int)pos.z == (int)newPos.z);
            apple.SetPosition(newPos);
        }

        protected override void OnConstructLate()
        {
            var entity = world.AddEntity();
            entity.Set(new AppleInitializer());
            apple = entity;
        }

        protected override void OnDeconstruct() {
            
        }

    }

}