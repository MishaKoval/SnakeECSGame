using ME.ECS;
using ME.ECS.Collections.LowLevel;
using Project.Features.Head.Components;
using Unity.Mathematics;
using UnityEngine;

namespace Project.Features.Trail.Systems
{
#pragma warning disable
    using Project.Components;
    using Project.Modules;
    using Project.Systems;
    using Project.Markers;
    using Components;
    using Modules;
    using Systems;
    using Markers;

#pragma warning restore

#if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
#endif
    public sealed class TrailPositionsSystem : ISystemFilter
    {
        private TrailFeature feature;
        
        private Queue<Vector3> trailsPosition;
        //private List<Vector3> positionList => trailsPosition.ToList();


        public ref Queue<Vector3> GetPositions()
        {
            return ref trailsPosition;
        }

        public World world { get; set; }

        void ISystemBase.OnConstruct()
        {
            this.GetFeature(out this.feature);
            var allocator = world.GetState().allocator;
            
            trailsPosition.Enqueue(ref allocator,new Vector3(0, 0, -1));
            trailsPosition.Enqueue(ref allocator,new Vector3(0, 0, -2));
            /*trailsPosition.Enqueue(ref allocator,new Vector3(0, 0, -3));
            trailsPosition.Enqueue(ref allocator,new Vector3(0, 0, -4));
            trailsPosition.Enqueue(ref allocator,new Vector3(0, 0, -5));
            trailsPosition.Enqueue(ref allocator,new Vector3(0, 0, -6));
            trailsPosition.Enqueue(ref allocator,new Vector3(0, 0, -7));
            trailsPosition.Enqueue(ref allocator,new Vector3(0, 0, -8));*/
        }

        void ISystemBase.OnDeconstruct()
        {
        }

#if !CSHARP_8_OR_NEWER
        bool ISystemFilter.jobs => false;
        int ISystemFilter.jobsBatchCount => 64;
#endif
        Filter ISystemFilter.filter { get; set; }

        Filter ISystemFilter.CreateFilter()
        {
            return Filter.Create("Filter-TrailMoveSystem").With<IsHead>().Push();
        }

        void ISystemFilter.AdvanceTick(in Entity entity, in float deltaTime)
        {
            trailsPosition.Enqueue(ref world.GetState().allocator,entity.GetPosition() - (float3)entity.Get<HeadDirection>().direction);
            trailsPosition.Dequeue(in world.GetState().allocator);
        }
    }
}