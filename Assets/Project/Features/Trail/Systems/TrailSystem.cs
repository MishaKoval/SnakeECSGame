using System.Collections.Generic;
using System.Linq;
using ME.ECS;
using Project.Features.Head.Components;
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
    public sealed class TrailSystem : ISystem, IAdvanceTick, IUpdate,IUpdateLate {
        
        private TrailFeature feature;

        public World world { get; set; }
        
        private Queue<Vector3> trailsPosition = new Queue<Vector3>();

        private Queue<Vector3> offsets = new Queue<Vector3>();

        public List<Vector3> positionList => trailsPosition.ToList();

        public List<Vector3> offsetsList => offsets.ToList();
        
        void ISystemBase.OnConstruct() {
            
            this.GetFeature(out this.feature);
            trailsPosition.Enqueue(new Vector3(0, 0, -1));
            trailsPosition.Enqueue(new Vector3(0, 0, -2));
        }
        
        void ISystemBase.OnDeconstruct() {}
        
        void IAdvanceTick.AdvanceTick(in float deltaTime) {}

        void IUpdate.Update(in float deltaTime)
        {
            
        }

        public void UpdateLate(in float deltaTime)
        {
            trailsPosition.Enqueue(world.GetFeature<HeadFeature>().GetHead().GetPosition());
            trailsPosition.Dequeue();
        }
    }
    
}