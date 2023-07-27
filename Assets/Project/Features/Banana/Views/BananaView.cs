using ME.ECS;

namespace Project.Features.Banana.Views {
    
    using ME.ECS.Views.Providers;
    
    public class BananaView : MonoBehaviourView {
        
        public override bool applyStateJob => true;

        public override void OnInitialize() {
            
        }
        
        public override void OnDeInitialize() {
            
        }
        
        public override void ApplyStateJob(UnityEngine.Jobs.TransformAccess transform, float deltaTime, bool immediately) {
            transform.position = entity.GetPosition();
        }
        
        public override void ApplyState(float deltaTime, bool immediately) {
            
        }
    }
    
}