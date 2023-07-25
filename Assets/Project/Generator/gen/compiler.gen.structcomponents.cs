namespace ME.ECS {

    public static partial class ComponentsInitializer {

        static partial void InitTypeIdPartial() {

            WorldUtilities.ResetTypeIds();

            CoreComponentsInitializer.InitTypeId();


            WorldUtilities.InitComponentTypeId<Project.Components.BallDirection>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.BallLaunchTime>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.BallRadius>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.BallSpawnTime>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.CurrentPlayer>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.BallLaunched>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.BallTag>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.Despawn>(true, true, true, false, false, false, false, false, false);

        }

        static partial void Init(State state, ref ME.ECS.World.NoState noState) {

            WorldUtilities.ResetTypeIds();

            CoreComponentsInitializer.InitTypeId();


            WorldUtilities.InitComponentTypeId<Project.Components.BallDirection>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.BallLaunchTime>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.BallRadius>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.BallSpawnTime>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.CurrentPlayer>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.BallLaunched>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.BallTag>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.Despawn>(true, true, true, false, false, false, false, false, false);

            ComponentsInitializerWorld.Setup(ComponentsInitializerWorldGen.Init);
            CoreComponentsInitializer.Init(state, ref noState);


            state.structComponents.ValidateUnmanaged<Project.Components.BallDirection>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Components.BallLaunchTime>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Components.BallRadius>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Components.BallSpawnTime>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Components.CurrentPlayer>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Components.BallLaunched>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Components.BallTag>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Components.Despawn>(ref state.allocator, true);

        }

    }

    public static class ComponentsInitializerWorldGen {

        public static void Init(Entity entity) {


            entity.ValidateDataUnmanaged<Project.Components.BallDirection>(false);
            entity.ValidateDataUnmanaged<Project.Components.BallLaunchTime>(false);
            entity.ValidateDataUnmanaged<Project.Components.BallRadius>(false);
            entity.ValidateDataUnmanaged<Project.Components.BallSpawnTime>(false);
            entity.ValidateDataUnmanaged<Project.Components.CurrentPlayer>(false);
            entity.ValidateDataUnmanaged<Project.Components.BallLaunched>(true);
            entity.ValidateDataUnmanaged<Project.Components.BallTag>(true);
            entity.ValidateDataUnmanaged<Project.Components.Despawn>(true);

        }

    }

}
