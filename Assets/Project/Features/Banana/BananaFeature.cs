using ME.ECS;
using Project.Features.Banana.Views;
using UnityEngine;

namespace Project.Features {

    using Components; using Modules; using Systems; using Features; using Markers;
    using Banana.Components; using Banana.Modules; using Banana.Systems; using Banana.Markers;
    
    namespace Banana.Components {}
    namespace Banana.Modules {}
    namespace Banana.Systems {}
    namespace Banana.Markers {}
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class BananaFeature : Feature
    {

        [SerializeField] private BananaView bananaView;

        public ViewId bananaId { get; private set; }

        protected override void OnConstruct()
        {
            bananaId = world.RegisterViewSource(bananaView);
            AddSystem<BananaInitSystem>();
            AddSystem<BananaSpawnSystem>();
            AddSystem<BananaTimerSystem>();
            AddSystem<BananaCollectSystem>();
            AddSystem<BananaDespawnSystem>();
        }

        public void SpawnBanana()
        {
            var entity = world.AddEntity();
            entity.Set(new BananaInitializer());
        }

        protected override void OnConstructLate()
        {
            //SpawnBanana();
        }

        protected override void OnDeconstruct() {
            
        }

    }

}