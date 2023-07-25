using ME.ECS;
using ME.ECS.Views.Providers;
using Project.Features.Trail.Views;
using UnityEngine;

namespace Project.Features {

    using Components; using Modules; using Systems; using Features; using Markers;
    using Trail.Components; using Trail.Modules; using Trail.Systems; using Trail.Markers;
    
    namespace Trail.Components {}
    namespace Trail.Modules {}
    namespace Trail.Systems {}
    namespace Trail.Markers {}
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class TrailFeature : Feature
    {
        [SerializeField] private TrailView trailView;
        
        protected override void OnConstruct() {
            
        }

        protected override void OnConstructLate()
        {
            base.OnConstructLate();
        }

        protected override void OnDeconstruct() {
            
        }
    }

}