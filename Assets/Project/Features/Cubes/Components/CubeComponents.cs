using ME.ECS;
using UnityEngine;

namespace Project.Features.Cubes.Components {

    public struct CubeInitializer : IStructComponent
    {
        public float speed;

        public UnityEngine.Vector3 dir;

        public UnityEngine.Vector3 pos;
    }
    
    public struct IsCube : IStructComponent {
        
    }
    
    
    public struct CubeSpeed : IStructComponent
    {
        public float speed;
    }
    
    public struct CubeDirection : IStructComponent
    {
        public Vector3 dir;
    }

}