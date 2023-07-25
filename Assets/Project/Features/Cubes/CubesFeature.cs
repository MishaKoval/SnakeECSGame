using ME.ECS;
using Project.Features.Cubes.Views;
using UnityEngine;

namespace Project.Features {

    using Components; using Modules; using Systems; using Features; using Markers;
    using Cubes.Components; using Cubes.Modules; using Cubes.Systems; using Cubes.Markers;
    
    namespace Cubes.Components {}
    namespace Cubes.Modules {}
    namespace Cubes.Systems {}
    namespace Cubes.Markers {}
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class CubesFeature : Feature {

	   public CubeView cubeView;

        protected override void OnConstruct()
        {
            var viewId = this.world.RegisterViewSource(this.cubeView);
            var cube = this.world.AddEntity();
            cube.Set(new CubeInitializer());
            cube.Set(new IsCube());
            cube.Set(new CubeSpeed());
            cube.Set(new CubeDirection());
            cube.InstantiateView(viewId);
        }

        protected override void OnDeconstruct() {
            
        }

    }

}