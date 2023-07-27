﻿using ME.ECS;
using ME.ECS.Views.Providers;
using Project.Features.Trail.Views;
using Unity.Mathematics;
using UnityEngine;

namespace Project.Features {

    using Components; using Modules; using Systems; using Features; using Markers;
    using Trail.Components; using Trail.Modules; using Trail.Systems; using Trail.Markers;
    
    namespace Trail.Components {}
    namespace Trail.Modules {}
    namespace Trail.Systems {}
    namespace Trail.Markers {}
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class TrailFeature : Feature
    {
        [SerializeField] private TrailView trailView;
        
        public ViewId TrailId { get; private set;}
        
        private Entity trailsData;

        public Entity GetTrailsData()
        {
            return trailsData;
        }

        protected override void OnConstruct() {
            TrailId = world.RegisterViewSource(trailView);
            AddSystem<TrailInitSystem>();
            AddSystem<TrailPositionsSystem>();
            AddSystem<TrailMoveSystem>();
            AddSystem<TrailSpawnSystem>();
            
            var data= world.AddEntity();
            data.Set(new TrailsData());
            trailsData = data;
        }

        protected override void OnConstructLate()
        {
            for (int i = 0; i < 2; i++)
            {
                SpawnTrail(new Vector3(0, 0, -i - 1));
            }
        }

        private void SpawnTrail(Vector3 pos)
        {
            var entity = world.AddEntity();
            entity.Set(new TrailInitializer()
            {
                position = pos,
            });
            trailsData.Get<TrailsData>().Trails.Add(ref world.GetState().allocator,entity);
        }

        public void SpawnLastTrail()
        {
            var pos = GetLastTrailPos();
            SpawnTrail(GetLastTrailPos());
        }
        
        private float3 GetLastTrailPos()
        {
            return trailsData.Get<TrailsData>()
                .Trails[in world.GetState().allocator, trailsData.Get<TrailsData>().Trails.Count - 1].GetPosition();
        }

        protected override void OnDeconstruct() {
            
        }
    }

}