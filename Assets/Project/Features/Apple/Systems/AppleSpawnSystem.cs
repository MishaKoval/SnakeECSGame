using ME.ECS;
using Project.Markers.GameActionsMarkers;

namespace Project.Features.Apple.Systems {

    #pragma warning disable
    using Project.Components; using Project.Modules; using Project.Systems; using Project.Markers;
    using Components; using Modules; using Systems; using Markers;
    #pragma warning restore
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class AppleSpawnSystem : ISystem, IUpdate {
        
        private AppleFeature feature;

        public World world { get; set; }
        
        void ISystemBase.OnConstruct() {
            
            this.GetFeature(out this.feature);
        }
        
        void ISystemBase.OnDeconstruct() {}
        
        //void IAdvanceTick.AdvanceTick(in float deltaTime) {}

        void IUpdate.Update(in float deltaTime)
        {
            if (world.GetMarker(out CollectAppleMarker _))
            {
                feature.ChangeApplePos();
            }
        }
        
    }
    
}