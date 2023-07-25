using ME.ECS;
using ME.ECS.Views.Providers;

namespace Project.Features {

    using Components; using Modules; using Systems; using Features; using Markers;
    using Head.Components; using Head.Modules; using Head.Systems; using Head.Markers;
    
    namespace Head.Components {}
    namespace Head.Modules {}
    namespace Head.Systems {}
    namespace Head.Markers {}
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class HeadFeature : Feature
    {
        private MonoBehaviourView headView;
        
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