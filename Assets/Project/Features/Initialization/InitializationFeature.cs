using ME.ECS;
using UnityEngine;

namespace Project.Features {
    using Initialization.Modules;

    namespace Initialization.Components {}
    namespace Initialization.Modules {}
    namespace Initialization.Systems {}
    namespace Initialization.Markers {}
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class InitializationFeature : Feature
    {
        [SerializeField] private GlobalEvent gameCreated;
        
        [SerializeField] private GlobalEvent startLoading;

        public void OnGameCreated()
        {
            gameCreated.Execute();
        }
        
        public void OnStartGameLoading()
        {
            startLoading.Execute();
        }

        protected override void OnConstruct()
        {
            AddModule<NetworkEventsModule>();
            AddModule<ResetGameModule>();
        }

        protected override void OnDeconstruct() { }
    }

}