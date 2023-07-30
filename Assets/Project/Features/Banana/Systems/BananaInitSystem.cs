using ME.ECS;
using Project.Features.Trail.Components;
using Unity.Mathematics;

namespace Project.Features.Banana.Systems {

    #pragma warning disable
    using Project.Components;
    using Components;

#pragma warning restore
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class BananaInitSystem : ISystemFilter {
        
        private BananaFeature feature;

        private const float LifeTime = 5.0f;
        
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
            return Filter.Create("Filter-BananaInitSystem").With<BananaInitializer>().WithoutShared<WaitGameInitialization>().Push();
        }

        private void SetBananaPos(in Entity banana)
        {
            var trails  = world.GetFeature<TrailFeature>().GetTrailsData().Get<TrailsData>().Trails;
            float3 newPos;
            bool isOnTrail;
            do
            {
                isOnTrail = false;
                int newPosX = world.GetRandomRange(0, 31);
                int newPosZ = world.GetRandomRange(0, 31);
                newPos = new float3(newPosX, 0, newPosZ);
                for (int i = 0; i < trails.Count; i++)
                {
                    if ( (int)newPos.x == (int)trails[in world.GetState().allocator,i].GetPosition().x && 
                         (int)newPos.z == (int)trails[in world.GetState().allocator,i].GetPosition().z)
                    {
                        isOnTrail = true;
                    }
                }
            } while (isOnTrail);
            banana.SetPosition(newPos);
        }

        void ISystemFilter.AdvanceTick(in Entity entity, in float deltaTime)
        {
            entity.Set(new IsBanana()
            {
                LifeTime = LifeTime
            });
            SetBananaPos(in entity);
            world.InstantiateView(feature.bananaId,entity);
            entity.Remove<BananaInitializer>();
        }
    }
}