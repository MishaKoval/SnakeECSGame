using ME.ECS;

namespace Project.Features.Apple.Components {

    public struct AppleInitializer : IComponent
    {
        
    }

    public struct IsApple : IComponent {
        
    }

    public struct CollectedApples : IComponent
    {
        public int ApplesCount;
    }

}