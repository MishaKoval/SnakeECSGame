using ME.ECS;
using Project.Components;
using UnityEngine;

namespace Project.Features {
    using WebSocketNetwork.Modules;

    namespace WebSocketNetwork.Components {}
    namespace WebSocketNetwork.Modules {}
    namespace WebSocketNetwork.Systems {}
    namespace WebSocketNetwork.Markers {}
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class WebSocketNetworkFeature : Feature
    {
        [SerializeField] public string webSocketUrl;
            
        protected override void OnConstruct() {
            AddModule<WebSocketModule>();
            world.SetSharedData(new WaitGameInitialization());
        }

        protected override void OnDeconstruct()
        {
            
        }
    }

}