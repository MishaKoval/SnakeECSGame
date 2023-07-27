using ME.ECS;
using Unity.Mathematics;
using UnityEngine;

namespace Project.Features.Head.Systems {

    #pragma warning disable
    using Project.Components; using Project.Modules; using Project.Systems; using Project.Markers;
    using Components; using Modules; using Systems; using Markers;
    #pragma warning restore
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class CheckBorderSystem : ISystemFilter {
        
        private HeadFeature feature;
        
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
            
            return Filter.Create("Filter-CheckBorderSystem").With<IsHead>().Push();
            
        }

        void ISystemFilter.AdvanceTick(in Entity entity, in float deltaTime)
        {
            float3 pos = entity.GetPosition();
            
            if (pos.x > 31f)
            {
                entity.SetPosition(new float3(0,pos.y,pos.z));
            }
            
            if (pos.x < 0f)
            {
                entity.SetPosition(new float3(31,pos.y,pos.z));
            }
            
            if (pos.z > 31f)
            {
                entity.SetPosition(new float3(pos.x,pos.y,0));
            }
            
            if (pos.z < 0f)
            {
                entity.SetPosition(new float3(pos.x,pos.y,31));
            }
        }
    
    }
    
}