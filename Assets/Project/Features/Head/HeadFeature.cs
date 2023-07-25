using ME.ECS;
using Project.Features.Head.Views;
using UnityEngine;

namespace Project.Features {
    using Head.Components;
    using Head.Systems;

    namespace Head.Components {}
    namespace Head.Modules {}
    namespace Head.Systems {}
    namespace Head.Markers {}
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class HeadFeature : Feature
    {
        [SerializeField] private HeadView headView;
        [SerializeField] private Vector3 startPos;
        
        //private Filter _headFilter;
        
        public ViewId HeadId { get; private set;}
        
        protected override void OnConstruct() {
            HeadId = world.RegisterViewSource(headView);
            AddSystem<HeadInitSystem>();
            AddSystem<HeadMoveSystem>();
            
            /*Filter.Create("Head-Filter")
                .With<IsHead>()
                .Push(ref _headFilter);*/
        }
        
        /*public Entity GetHead()
        {
            if (_headFilter.Count > 0)
            {
                return _headFilter.ToArray()[0];
            }
            return Entity.Empty;
        }*/
        
        protected override void OnConstructLate()
        {
            var entity = world.AddEntity();
            entity.Set(new HeadInitializer()
            {
                position = startPos,
                direction = Vector3.forward,
                speed = 3.0f
            });
        }

        protected override void OnDeconstruct() {
            
        }

    }

}