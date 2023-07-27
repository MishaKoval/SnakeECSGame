using ME.ECS;
using UnityEngine;

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
    public sealed class TrailSpawnSystem :  ISystem, IUpdate {
        
        private TrailFeature feature;
        
        public World world { get; set; }
        
        void ISystemBase.OnConstruct() {
            
            this.GetFeature(out this.feature);
        }
        
        void ISystemBase.OnDeconstruct() {}

        public void Update(in float deltaTime)
        {
            if (world.GetMarker(out SpaceKeyMarker _))
            {
                world.GetSystem<TrailPositionsSystem>().GetPositions().Enqueue(ref world.GetState().allocator,world.GetFeature<HeadFeature>().GetHead().GetPosition());
                feature.SpawnLastTrail();
            }
        }
    }
    
}