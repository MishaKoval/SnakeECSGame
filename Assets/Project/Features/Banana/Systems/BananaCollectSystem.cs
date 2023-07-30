using ME.ECS;
using Project.Features.Apple.Systems;
using Project.Markers.GameActionsMarkers;
using UnityEngine;

namespace Project.Features.Banana.Systems {

    #pragma warning disable
    using Project.Components; using Project.Modules; using Project.Systems; using Project.Markers;
    using Components; using Modules; using Systems; using Markers;
    #pragma warning restore
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class BananaCollectSystem : ISystemFilter {
        
        private const float MinDistance = 0.1f;
        
        private BananaFeature feature;
        
        public World world { get; set; }
        
        void ISystemBase.OnConstruct() {
            
            this.GetFeature(out this.feature);
            
        }
        
        void ISystemBase.OnDeconstruct() {}
        
        #if !CSHARP_8_OR_NEWER
        bool ISystemFilter.jobs => false;
        int ISystemFilter.jobsBatchCount => 64;
        #endif
        Filter ISystemFilter.filter { get; set; }
        Filter ISystemFilter.CreateFilter() {
            
            return Filter.Create("Filter-BananaCollectSystem").With<IsBanana>().Push();
            
        }

        void ISystemFilter.AdvanceTick(in Entity entity, in float deltaTime)
        {
            if (((Vector3)world.GetFeature<HeadFeature>().GetHead().GetPosition() - (Vector3)entity.GetPosition()).sqrMagnitude < MinDistance)
            {
                feature.OnCollectFood();
                world.AddMarker(new CollectBananaMarker());
                entity.Set(new Despawn());
            }
        }
    
    }
    
}