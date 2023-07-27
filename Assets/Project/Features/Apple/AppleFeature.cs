using ME.ECS;
using Project.Features.Apple.Views;
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
        
        protected override void OnConstruct() {
            
        }

        protected override void OnDeconstruct() {
            
        }

    }

}