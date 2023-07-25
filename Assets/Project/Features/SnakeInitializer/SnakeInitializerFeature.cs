using ME.ECS;

namespace Project.Features {

    using Components; using Modules; using Systems; using Features; using Markers;
    using SnakeInitializer.Components; using SnakeInitializer.Modules; using SnakeInitializer.Systems; using SnakeInitializer.Markers;
    
    namespace SnakeInitializer.Components {}
    namespace SnakeInitializer.Modules {}
    namespace SnakeInitializer.Systems {}
    namespace SnakeInitializer.Markers {}
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class SnakeInitializerFeature : Feature {

        protected override void OnConstruct() {
            
        }

        protected override void OnDeconstruct() {
            
        }

    }

}