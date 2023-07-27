using ME.ECS;

namespace Project.Features.Trail.Systems {

    #pragma warning disable
    using Project.Components; using Project.Modules; using Project.Systems; using Project.Markers;
    using Components; using Modules; using Systems; using Markers;
    #pragma warning restore
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class TrailInitSystem : ISystemFilter {
        
        private TrailFeature feature;
        
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
            return Filter.Create("Filter-TrailInitSystem").With<TrailInitializer>().Push();
        }

        void ISystemFilter.AdvanceTick(in Entity entity, in float deltaTime)
        {
            var date = entity.Get<TrailInitializer>();
            entity.SetPosition(date.position);
            world.InstantiateView(feature.TrailId,entity);
            entity.Remove<TrailInitializer>();
            entity.Set(new IsTrail(){id = date.id,position = date.position});
        }
    
    }
    
}