using ME.ECS;
using Project.Components;
using Project.Features.Trail.Systems;
using Project.Features.WebSocketNetwork.Modules;
using Project.Markers.NetworkMarkers;

namespace Project.Features.Initialization.Modules {
#if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class InitNetworkModule : IModule, IUpdate {
        
        private InitializationFeature feature;
        
        public World world { get; set; }
        
        void IModuleBase.OnConstruct() {
            this.feature = this.world.GetFeature<InitializationFeature>();
        }
        
        void IModuleBase.OnDeconstruct() {}

        void IUpdate.Update(in float deltaTime)
        {
            if (world.GetMarker(out NetworkInitialized _))
            {
                feature.OnStartGameLoading();
                world.GetModule<WebSocketModule>().SendStartGameRequest();
            }
            if (world.GetMarker(out GameRestarted _))
            {
                feature.OnStartGameLoading();
                world.GetModule<WebSocketModule>().SendStartGameRequest();
            }
            if (world.GetMarker(out GameCreated _))
            {
                world.RemoveSharedData<WaitGameInitialization>();
                if (world.HasSharedData<GamePaused>())
                {
                    world.RemoveSharedData<GamePaused>();
                    world.GetFeature<HeadFeature>().ResetHead();
                    world.GetSystem<TrailPositionsSystem>().ResetPositions();
                    world.GetFeature<TrailFeature>().ResetTrail();
                }
                feature.OnGameCreated();
            }
        }
    }
    
}
