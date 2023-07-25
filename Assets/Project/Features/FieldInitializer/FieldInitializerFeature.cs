using ME.ECS;

namespace Project.Features {

    using Components; using Modules; using Systems; using Features; using Markers;
    using FieldInitializer.Components; using FieldInitializer.Modules; using FieldInitializer.Systems; using FieldInitializer.Markers;
    
    namespace FieldInitializer.Components {}
    namespace FieldInitializer.Modules {}
    namespace FieldInitializer.Systems {}
    namespace FieldInitializer.Markers {}
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class FieldInitializerFeature : Feature {

        protected override void OnConstruct() {
            
        }

        protected override void OnDeconstruct() {
            
        }

    }

}