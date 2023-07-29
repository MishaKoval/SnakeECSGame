namespace ME.ECS {

    public static partial class ComponentsInitializer {

        static partial void InitTypeIdPartial() {

            WorldUtilities.ResetTypeIds();

            CoreComponentsInitializer.InitTypeId();


            WorldUtilities.InitComponentTypeId<Project.Features.Apple.Components.CollectedApples>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Head.Components.HeadDirection>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Head.Components.HeadInitializer>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Head.Components.HeadSpeed>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Trail.Components.TrailInitializer>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Trail.Components.TrailsData>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.GamePaused>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.WaitGameInitialization>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Apple.Components.AppleInitializer>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Apple.Components.IsApple>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Banana.Components.BananaInitializer>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Banana.Components.Despawn>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Banana.Components.IsBanana>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Head.Components.IsHead>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Trail.Components.Despawn>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Trail.Components.IsTrail>(true, true, true, false, false, false, false, false, false);

        }

        static partial void Init(State state, ref ME.ECS.World.NoState noState) {

            WorldUtilities.ResetTypeIds();

            CoreComponentsInitializer.InitTypeId();


            WorldUtilities.InitComponentTypeId<Project.Features.Apple.Components.CollectedApples>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Head.Components.HeadDirection>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Head.Components.HeadInitializer>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Head.Components.HeadSpeed>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Trail.Components.TrailInitializer>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Trail.Components.TrailsData>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.GamePaused>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.WaitGameInitialization>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Apple.Components.AppleInitializer>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Apple.Components.IsApple>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Banana.Components.BananaInitializer>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Banana.Components.Despawn>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Banana.Components.IsBanana>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Head.Components.IsHead>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Trail.Components.Despawn>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Trail.Components.IsTrail>(true, true, true, false, false, false, false, false, false);

            ComponentsInitializerWorld.Setup(ComponentsInitializerWorldGen.Init);
            CoreComponentsInitializer.Init(state, ref noState);


            state.structComponents.ValidateUnmanaged<Project.Features.Apple.Components.CollectedApples>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Head.Components.HeadDirection>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Head.Components.HeadInitializer>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Head.Components.HeadSpeed>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Trail.Components.TrailInitializer>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Trail.Components.TrailsData>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Components.GamePaused>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Components.WaitGameInitialization>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Features.Apple.Components.AppleInitializer>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Features.Apple.Components.IsApple>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Features.Banana.Components.BananaInitializer>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Features.Banana.Components.Despawn>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Features.Banana.Components.IsBanana>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Features.Head.Components.IsHead>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Features.Trail.Components.Despawn>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Features.Trail.Components.IsTrail>(ref state.allocator, true);

        }

    }

    public static class ComponentsInitializerWorldGen {

        public static void Init(Entity entity) {


            entity.ValidateDataUnmanaged<Project.Features.Apple.Components.CollectedApples>(false);
            entity.ValidateDataUnmanaged<Project.Features.Head.Components.HeadDirection>(false);
            entity.ValidateDataUnmanaged<Project.Features.Head.Components.HeadInitializer>(false);
            entity.ValidateDataUnmanaged<Project.Features.Head.Components.HeadSpeed>(false);
            entity.ValidateDataUnmanaged<Project.Features.Trail.Components.TrailInitializer>(false);
            entity.ValidateDataUnmanaged<Project.Features.Trail.Components.TrailsData>(false);
            entity.ValidateDataUnmanaged<Project.Components.GamePaused>(true);
            entity.ValidateDataUnmanaged<Project.Components.WaitGameInitialization>(true);
            entity.ValidateDataUnmanaged<Project.Features.Apple.Components.AppleInitializer>(true);
            entity.ValidateDataUnmanaged<Project.Features.Apple.Components.IsApple>(true);
            entity.ValidateDataUnmanaged<Project.Features.Banana.Components.BananaInitializer>(true);
            entity.ValidateDataUnmanaged<Project.Features.Banana.Components.Despawn>(true);
            entity.ValidateDataUnmanaged<Project.Features.Banana.Components.IsBanana>(true);
            entity.ValidateDataUnmanaged<Project.Features.Head.Components.IsHead>(true);
            entity.ValidateDataUnmanaged<Project.Features.Trail.Components.Despawn>(true);
            entity.ValidateDataUnmanaged<Project.Features.Trail.Components.IsTrail>(true);

        }

    }

}
