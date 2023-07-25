namespace ME.ECS {

    public static partial class ComponentsInitializer {

        static partial void InitTypeIdPartial() {

            WorldUtilities.ResetTypeIds();

            CoreComponentsInitializer.InitTypeId();


            WorldUtilities.InitComponentTypeId<Project.Features.Cubes.Components.CubeDirection>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Cubes.Components.CubeInitializer>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Cubes.Components.CubeSpeed>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Cubes.Components.IsCube>(true, true, true, false, false, false, false, false, false);

        }

        static partial void Init(State state, ref ME.ECS.World.NoState noState) {

            WorldUtilities.ResetTypeIds();

            CoreComponentsInitializer.InitTypeId();


            WorldUtilities.InitComponentTypeId<Project.Features.Cubes.Components.CubeDirection>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Cubes.Components.CubeInitializer>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Cubes.Components.CubeSpeed>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Cubes.Components.IsCube>(true, true, true, false, false, false, false, false, false);

            ComponentsInitializerWorld.Setup(ComponentsInitializerWorldGen.Init);
            CoreComponentsInitializer.Init(state, ref noState);


            state.structComponents.ValidateUnmanaged<Project.Features.Cubes.Components.CubeDirection>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Cubes.Components.CubeInitializer>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Cubes.Components.CubeSpeed>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Cubes.Components.IsCube>(ref state.allocator, true);

        }

    }

    public static class ComponentsInitializerWorldGen {

        public static void Init(Entity entity) {


            entity.ValidateDataUnmanaged<Project.Features.Cubes.Components.CubeDirection>(false);
            entity.ValidateDataUnmanaged<Project.Features.Cubes.Components.CubeInitializer>(false);
            entity.ValidateDataUnmanaged<Project.Features.Cubes.Components.CubeSpeed>(false);
            entity.ValidateDataUnmanaged<Project.Features.Cubes.Components.IsCube>(true);

        }

    }

}
