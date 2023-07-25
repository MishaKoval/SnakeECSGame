using ME.ECS;
using UnityEngine;

namespace Project.Features.Head.Components {

    public struct HeadInitializer : IComponent
    {
        public float speed;
        public Vector3 direction;
        public Vector3 position;
    }
    
    public struct IsHead : IComponent {
        
    }
    
    public struct HeadSpeed : IComponent {
        public float speed;
    }
    
    public struct HeadDirection : IComponent {
        public Vector3 direction;
    }

}