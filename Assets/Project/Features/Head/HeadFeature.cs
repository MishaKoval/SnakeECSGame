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
        [SerializeField] private GlobalEvent gameOver;
        [SerializeField] private HeadView headView;
        [SerializeField] private Vector3 startPos;
        
        private Entity _headEntity;
        
        public ViewId HeadId { get; private set;}
        
        public void OnGameOver()
        {
            gameOver.Execute();
        }
        
        protected override void OnConstruct() {
            HeadId = world.RegisterViewSource(headView);
            AddSystem<HeadInitSystem>();
            AddSystem<HeadMoveSystem>();
            AddSystem<CheckBorderSystem>();
            AddSystem<HeadCollideTailSystem>();
        }
        
        public Entity GetHead()
        {
            return _headEntity;
        }

        public void ResetHead()
        {
            _headEntity.SetPosition(startPos);
        }

        protected override void OnConstructLate()
        {
            var entity = world.AddEntity();
            _headEntity = entity;
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