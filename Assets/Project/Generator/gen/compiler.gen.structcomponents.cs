namespace ME.ECS {

    public static partial class ComponentsInitializer {

        static partial void InitTypeIdPartial() {

            WorldUtilities.ResetTypeIds();

            CoreComponentsInitializer.InitTypeId();


            WorldUtilities.InitComponentTypeId<Project.Features.FieldElement.Components.FieldElementInitializer>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Head.Components.HeadDirection>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Head.Components.HeadInitializer>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Head.Components.HeadSpeed>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.FieldElement.Components.IsFieldElement>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Head.Components.IsHead>(true, true, true, false, false, false, false, false, false);

        }

        static partial void Init(State state, ref ME.ECS.World.NoState noState) {

            WorldUtilities.ResetTypeIds();

            CoreComponentsInitializer.InitTypeId();


            WorldUtilities.InitComponentTypeId<Project.Features.FieldElement.Components.FieldElementInitializer>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Head.Components.HeadDirection>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Head.Components.HeadInitializer>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Head.Components.HeadSpeed>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.FieldElement.Components.IsFieldElement>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Head.Components.IsHead>(true, true, true, false, false, false, false, false, false);

            ComponentsInitializerWorld.Setup(ComponentsInitializerWorldGen.Init);
            CoreComponentsInitializer.Init(state, ref noState);


            state.structComponents.ValidateUnmanaged<Project.Features.FieldElement.Components.FieldElementInitializer>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Head.Components.HeadDirection>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Head.Components.HeadInitializer>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Head.Components.HeadSpeed>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.FieldElement.Components.IsFieldElement>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Features.Head.Components.IsHead>(ref state.allocator, true);

        }

    }

    public static class ComponentsInitializerWorldGen {

        public static void Init(Entity entity) {


            entity.ValidateDataUnmanaged<Project.Features.FieldElement.Components.FieldElementInitializer>(false);
            entity.ValidateDataUnmanaged<Project.Features.Head.Components.HeadDirection>(false);
            entity.ValidateDataUnmanaged<Project.Features.Head.Components.HeadInitializer>(false);
            entity.ValidateDataUnmanaged<Project.Features.Head.Components.HeadSpeed>(false);
            entity.ValidateDataUnmanaged<Project.Features.FieldElement.Components.IsFieldElement>(true);
            entity.ValidateDataUnmanaged<Project.Features.Head.Components.IsHead>(true);

        }

    }

}
