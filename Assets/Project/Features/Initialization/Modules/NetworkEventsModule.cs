using ME.ECS;
using Project.Features.WebSocketNetwork.Modules;
using Project.Markers.GameActionsMarkers;
using Project.Markers.NetworkMarkers;
using UnityEngine;

namespace Project.Features.Initialization.Modules {
#if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class NetworkEventsModule : IModule, IUpdate {
        
        private InitializationFeature feature;
        
        public World world { get; set; }

        private int collectedApples = 0;

        public void ResetCollectdApples()
        {
            collectedApples = 0;
        }

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
            if (world.GetMarker(out GameOverMarker _))
            {
                world.GetModule<WebSocketModule>().SendEndGameRequest();
            }
            if (world.GetMarker(out CollectAppleMarker _))
            {
                collectedApples++;
                world.GetModule<WebSocketModule>().SendCollectAppleRequest(collectedApples);
            }
            if (world.GetMarker(out CollectBananaMarker _))
            {
                collectedApples += 2;
                world.GetModule<WebSocketModule>().SendCollectAppleRequest(collectedApples);
            }
        }
    }
}
