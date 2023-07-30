using ME.ECS;
using Project.Markers.GameActionsMarkers;

namespace Project.Features.Trail.Systems {

    #pragma warning disable
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
            if (world.GetMarker(out CollectAppleMarker _))
            {
                world.GetSystem<TrailPositionsSystem>().GetPositions().Enqueue(ref world.GetState().allocator,world.GetFeature<HeadFeature>().GetHead().GetPosition());
                feature.SpawnLastTrail();
            }

            if (world.GetMarker(out CollectBananaMarker _))
            {
                for (int i = 0; i < 2; i++)
                {
                    world.GetSystem<TrailPositionsSystem>().GetPositions().Enqueue(ref world.GetState().allocator,world.GetFeature<HeadFeature>().GetHead().GetPosition());
                    feature.SpawnLastTrail();
                }
            }
        }
    }
    
}