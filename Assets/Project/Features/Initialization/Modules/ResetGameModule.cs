using ME.ECS;
using Project.Components;
using Project.Features.Banana.Systems;
using Project.Features.Trail.Systems;
using Project.Markers.NetworkMarkers;

namespace Project.Features.Initialization.Modules {

    #pragma warning disable
#pragma warning restore
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class ResetGameModule : IModule, IUpdate {
        
        private InitializationFeature feature;
        
        public World world { get; set; }
        
        void IModuleBase.OnConstruct() {
            this.feature = this.world.GetFeature<InitializationFeature>();
        }
        
        void IModuleBase.OnDeconstruct() {}

        void IUpdate.Update(in float deltaTime)
        {
            if (world.GetMarker(out GameCreatedMarker _))
            {
                world.RemoveSharedData<WaitGameInitialization>();
                if (world.HasSharedData<GamePaused>())
                {
                    world.RemoveSharedData<GamePaused>();
                    world.GetFeature<HeadFeature>().ResetHead();
                    world.GetSystem<TrailPositionsSystem>().ResetPositions();
                    world.GetFeature<TrailFeature>().ResetTrail();
                    world.GetSystem<BananaSpawnSystem>().ResetCollectedApples();
                    world.GetModule<NetworkEventsModule>().ResetCollectdApples();
                }
                feature.OnGameCreated();
            }
        }
    }
}