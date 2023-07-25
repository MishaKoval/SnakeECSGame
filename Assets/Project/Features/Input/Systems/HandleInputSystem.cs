using ME.ECS;
using Project.Features.Head.Components;
using UnityEngine;

namespace Project.Features.Input.Systems {

    #pragma warning disable
    using Project.Components; using Project.Modules; using Project.Systems; using Project.Markers;
    using Components; using Modules; using Systems; using Markers;
    #pragma warning restore
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class HandleInputSystem : ISystem, IUpdate {
        
        private InputFeature feature;

        private Filter _headFilter;

        private Entity? headEntity;//todo ??

        public World world { get; set; }
        
        void ISystemBase.OnConstruct() {
            
            this.GetFeature(out this.feature);
            Filter.Create("Head-Filter")
                .With<IsHead>()
                .Push(ref _headFilter);
        }

        void ISystemBase.OnDeconstruct()
        {
        }

        void IUpdate.Update(in float deltaTime)
        {
            if (headEntity == null)
            {
                if (_headFilter.Count > 0)
                {
                    var arr = _headFilter.ToArray();
                    headEntity = arr[0];
                    arr.Dispose();
                }
            }
            else
            {
                if (world.GetMarker(out LeftKeyMarker leftKeyMarker))
                {
                    headEntity.Value.Get<HeadDirection>().direction = Vector3.left;
                    Debug.Log("Pressed!" + nameof(leftKeyMarker));
                }
                if (world.GetMarker(out RightKeyMarker rightKeyMarker))
                {
                    headEntity.Value.Get<HeadDirection>().direction  = Vector3.right;
                    Debug.Log("Pressed!" + nameof(rightKeyMarker));
                }
                if (world.GetMarker(out UpKeyMarker upKeyMarker))
                {
                    headEntity.Value.Get<HeadDirection>().direction  = Vector3.forward;
                    Debug.Log("Pressed!" + nameof(upKeyMarker));
                }
                if (world.GetMarker(out DownKeyMarker downKeyMarker))
                {
                    headEntity.Value.Get<HeadDirection>().direction  = Vector3.back;
                    Debug.Log("Pressed!" + nameof(downKeyMarker));
                }
            }
          
        }
        
    }
    
}