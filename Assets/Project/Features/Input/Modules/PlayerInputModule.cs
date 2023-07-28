using ME.ECS;
using Project.Markers;
using Project.Markers.InputMarkers;
using UnityEngine;

namespace Project.Features.Input.Modules {
    
    using Components; using Modules; using Systems; using Features; using Markers;
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class PlayerInputModule : IModule, IUpdate {
        
        private InputFeature feature;
        
        public World world { get; set; }
        
        void IModuleBase.OnConstruct() {
            
            this.feature = this.world.GetFeature<InputFeature>();
        }
        
        void IModuleBase.OnDeconstruct() {}

        void IUpdate.Update(in float deltaTime)
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.A))
            {
                world.AddMarker(new LeftKeyMarker());
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.D))
            {
                world.AddMarker(new RightKeyMarker());
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.W))
            {
                world.AddMarker(new UpKeyMarker());
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.S))
            {
                world.AddMarker(new DownKeyMarker());
            }
            
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                world.AddMarker(new SpaceKeyMarker());
            }
        }
    }
    
}
