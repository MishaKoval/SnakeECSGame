using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ME.ECS;
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
    public sealed class TrailMoveSystem : ISystemFilter
    {
        private TrailFeature feature;
        
        private Queue<Vector3> trailsPosition = new Queue<Vector3>();
        private List<Vector3> positionList => trailsPosition.ToList();


        public World world { get; set; }

        void ISystemBase.OnConstruct()
        {
            this.GetFeature(out this.feature);
            trailsPosition.Enqueue(new Vector3(0, 0, -1));
            trailsPosition.Enqueue(new Vector3(0, 0, -2));
            trailsPosition.Enqueue(new Vector3(0, 0, -3));
            trailsPosition.Enqueue(new Vector3(0, 0, -4));
            trailsPosition.Enqueue(new Vector3(0, 0, -5));
            trailsPosition.Enqueue(new Vector3(0, 0, -6));
            trailsPosition.Enqueue(new Vector3(0, 0, -7));
            trailsPosition.Enqueue(new Vector3(0, 0, -8));
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
            return Filter.Create("Filter-TrailMoveSystem").With<IsTrail>().Push();
        }

        void ISystemFilter.AdvanceTick(in Entity entity, in float deltaTime)
        {
            if (entity.Get<IsTrail>().id == 0)
            {
                trailsPosition.Enqueue(world.GetFeature<HeadFeature>().GetHead().GetPosition() - (float3)world.GetFeature<HeadFeature>().GetHead().Get<HeadDirection>().direction);
                trailsPosition.Dequeue();
            }
            entity.SetPosition(positionList[entity.Get<IsTrail>().id]);
        }
    }
}