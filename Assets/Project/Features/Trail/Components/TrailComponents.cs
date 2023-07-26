using ME.ECS;
using UnityEngine;

namespace Project.Features.Trail.Components {

    public struct TrailInitializer : IComponent
    {
        public Vector3 position;
        public int id;
    }

    public struct IsTrail : IComponent
    {
        public int id;
        //public Vector3 position;
    }
    
}