﻿using ME.ECS;
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
    public sealed class TrailMoveSystem : ISystemFilter {
        
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
            
            return Filter.Create("Filter-TrailMoveSystem").With<TrailsData>().Push();
            
        }

        void ISystemFilter.AdvanceTick(in Entity entity, in float deltaTime)
        {
            var positions = world.GetSystem<TrailPositionsSystem>().GetPositions();
            var trails = entity.Get<TrailsData>().Trails;
            Debug.Log("Poses"+positions.Count);
            Debug.Log("Trails" + trails.Count);
            int trailIndex = 0;
            foreach (var pos in positions)
            {
                var trail = trails[in world.GetState().allocator,trailIndex];
                trail.SetPosition(pos);
                trailIndex++;
            }
        }
    
    }
    
}