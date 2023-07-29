using ME.ECS;
using Project.Components;
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
                world.GetModule<WebSocketModule>().SendStartGameRequest();
            }
            if (world.GetMarker(out GameCreated _))
            {
                world.RemoveSharedData<WaitGameInitialization>();
                feature.OnGameCreated();
            }
        }
    }
    
}
