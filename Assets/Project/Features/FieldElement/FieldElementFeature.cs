using ME.ECS;
using Project.Features.FieldElement.Components;
using Project.Features.FieldElement.Systems;
using Project.Features.FieldElement.Views;
using UnityEngine;

namespace Project.Features {
    namespace FieldElement.Components {}
    namespace FieldElement.Modules {}
    namespace FieldElement.Systems {}
    namespace FieldElement.Markers {}
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class FieldElementFeature : Feature
    {
        [SerializeField] private FieldView fieldElementView;

        public ViewId FieldId { get; private set;}

        protected override void OnConstruct()
        {
            FieldId = world.RegisterViewSource(fieldElementView);
            AddSystem<FieldInitSystem>();
        }
        
        protected override void OnConstructLate()
        {
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    var entity = world.AddEntity();
                    entity.Set(new FieldElementInitializer()
                    {
                        position = new Vector3(i,0,j)
                    });
                    Debug.Log(entity.Get<FieldElementInitializer>().position);
                }
            }
        }

        protected override void OnDeconstruct() {
            
        }
    }

}