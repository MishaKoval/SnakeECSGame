using ME.ECS;
using Project.Markers.GameActionsMarkers;
using UnityEngine;

namespace Project.Features.Banana.Systems {

    #pragma warning disable
#pragma warning restore
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class BananaSpawnSystem : ISystem,IUpdate {
        
        private BananaFeature feature;
        
        public World world { get; set; }

        private int collectedApples;

        private const int applesCountToGetBanana = 5;

        private bool isHaveBanana;

        public void ResetCollectedApples()
        {
            collectedApples = 0;
        }

        void ISystemBase.OnConstruct() {
            
            this.GetFeature(out this.feature);
        }
        
        void ISystemBase.OnDeconstruct() {}
        
        public void Update(in float deltaTime)
        {
            Debug.Log(collectedApples);
            if (world.GetMarker(out CollectAppleMarker _))
            {
                if (!isHaveBanana)
                {
                    collectedApples++;
                    if (collectedApples == applesCountToGetBanana)
                    {
                        isHaveBanana = true;
                        feature.SpawnBanana();
                        collectedApples = 0;
                    }
                }
            }
            if (world.GetMarker(out CollectBananaMarker _))
            {
                isHaveBanana = false;
            }
            if (world.GetMarker(out BananaDisappearMarker _))
            {
                isHaveBanana = false;
            }
        }
    }
    
}