using ME.ECS;
using Project.Features.Head.Components;
using Project.Markers.InputMarkers;
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

        public World world { get; set; }
        
        void ISystemBase.OnConstruct() {
            
            this.GetFeature(out this.feature);
        }

        void ISystemBase.OnDeconstruct()
        {
        }

        void IUpdate.Update(in float deltaTime)
        {
            if (world.GetMarker(out LeftKeyMarker leftKeyMarker))
            {
                if( world.GetFeature<HeadFeature>().GetHead().Get<HeadDirection>().direction != Vector3.right)
                    world.GetFeature<HeadFeature>().GetHead().Get<HeadDirection>().direction = Vector3.left;
            }
            if (world.GetMarker(out RightKeyMarker rightKeyMarker))
            {
                if( world.GetFeature<HeadFeature>().GetHead().Get<HeadDirection>().direction != Vector3.left)
                    world.GetFeature<HeadFeature>().GetHead().Get<HeadDirection>().direction = Vector3.right;
            }
            if (world.GetMarker(out UpKeyMarker upKeyMarker))
            {
                if( world.GetFeature<HeadFeature>().GetHead().Get<HeadDirection>().direction != Vector3.back)
                    world.GetFeature<HeadFeature>().GetHead().Get<HeadDirection>().direction = Vector3.forward;
            }
            if (world.GetMarker(out DownKeyMarker downKeyMarker))
            {
                if( world.GetFeature<HeadFeature>().GetHead().Get<HeadDirection>().direction != Vector3.forward)
                    world.GetFeature<HeadFeature>().GetHead().Get<HeadDirection>().direction = Vector3.back;
            }
        }
        
    }
    
}