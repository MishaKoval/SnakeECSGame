using ME.ECS;
using Project.Components;
using Project.Features.Trail.Components;
using UnityEngine;

namespace Project.Features.Head.Systems {

    #pragma warning disable
#pragma warning restore
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class HeadCollideTailSystem : ISystemFilter
    {
        private const float minDistance = 0.01f;
        
        private HeadFeature feature;
        
        public World world { get; set; }
        
        void ISystemBase.OnConstruct() {
            
            this.GetFeature(out this.feature);
        }
        
        void ISystemBase.OnDeconstruct() {}
        
        #if !CSHARP_8_OR_NEWER
        bool ISystemFilter.jobs => true;
        int ISystemFilter.jobsBatchCount => 64;
        #endif
        Filter ISystemFilter.filter { get; set; }
        Filter ISystemFilter.CreateFilter() {
            return Filter.Create("Filter-HeadCollideTailSystem").With<IsTrail>().WithoutShared<GamePaused>().Push();
        }
        
        void ISystemFilter.AdvanceTick(in Entity entity, in float deltaTime)
        {
            if (((Vector3)feature.GetHead().GetPosition() - (Vector3)entity.GetPosition()).sqrMagnitude < minDistance)
            {
                feature.OnGameOver();
                world.SetSharedData(new GamePaused());
            }
        }
    }
}