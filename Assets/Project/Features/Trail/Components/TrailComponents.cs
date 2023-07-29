using ME.ECS;
using ME.ECS.Collections.LowLevel;
using UnityEngine;

namespace Project.Features.Trail.Components {

    public struct TrailInitializer : IComponent
    {
        public Vector3 position;
    }

    public struct IsTrail : IComponent
    {
    }
    
    public struct Despawn : IComponent{ }

    public struct TrailsData : IComponent
    {
        public List<Entity> Trails;
    }

}