using ME.ECS;
using Project.Components;
using Project.Features.Apple.Systems;
using Project.Features.Trail.Systems;
using Project.Features.WebSocketNetwork.Modules;
using Project.Markers.GameActionsMarkers;
using Project.Markers.NetworkMarkers;

namespace Project.Features.Initialization.Modules {
#if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class NetworkEventsModule : IModule, IUpdate {
        
        private InitializationFeature feature;
        
        public World world { get; set; }
        
        void IModuleBase.OnConstruct() {
            this.feature = this.world.GetFeature<InitializationFeature>();
        }
        
        void IModuleBase.OnDeconstruct() {}

        void IUpdate.Update(in float deltaTime)
        {
            if (world.GetMarker(out NetworkInitializedMarker _))
            {
                feature.OnStartGameLoading();
                world.GetModule<WebSocketModule>().SendStartGameRequest();
            }
            if (world.GetMarker(out GameRestartedMarker _))
            {
                feature.OnStartGameLoading();
                world.GetModule<WebSocketModule>().SendStartGameRequest();
            }
            if (world.GetMarker(out GameCreatedMarker _))
            {
                world.RemoveSharedData<WaitGameInitialization>();
                if (world.HasSharedData<GamePaused>())
                {
                    world.RemoveSharedData<GamePaused>();
                    world.GetFeature<HeadFeature>().ResetHead();
                    world.GetSystem<TrailPositionsSystem>().ResetPositions();
                    world.GetFeature<TrailFeature>().ResetTrail();
                    world.GetSystem<AppleCollectSystem>().ResetAppleCount();
                }
                feature.OnGameCreated();
            }
            if (world.GetMarker(out GameOverMarker _))
            {
                world.GetModule<WebSocketModule>().SendEndGameRequest();
            }
            if (world.GetMarker(out CollectAppleMarker collectAppleMarker))
            {
                world.GetModule<WebSocketModule>().SendCollectAppleRequest(collectAppleMarker.ApplesCount);
            }
        }
    }
    
}
