using ME.ECS;
using Project.Markers.GameActionsMarkers;

namespace Project.Features.Banana.Systems {

    #pragma warning disable
    using Components;

#pragma warning restore
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class BananaTimerSystem : ISystemFilter {
        
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
            
            return Filter.Create("Filter-BananaTimerSystem").With<IsBanana>().Without<Despawn>().Push();
            
        }

        void ISystemFilter.AdvanceTick(in Entity entity, in float deltaTime)
        {
            entity.Get<IsBanana>().LifeTime -= deltaTime;

            if (entity.Get<IsBanana>().LifeTime <= 0)
            {
                world.AddMarker(new BananaDisappearMarker());
                entity.Set<Despawn>();
            }
        }
    
    }
    
}