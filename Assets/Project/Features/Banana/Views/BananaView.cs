using ME.ECS;
using UnityEngine;

namespace Project.Features.Banana.Views {
    
    using ME.ECS.Views.Providers;
    
    public class BananaView : MonoBehaviourView {
        
        public override bool applyStateJob => true;

        private int _rotateAngle;

        public override void OnInitialize() {
            
        }
        
        public override void OnDeInitialize() {
            
        }
        
        public override void ApplyStateJob(UnityEngine.Jobs.TransformAccess transform, float deltaTime, bool immediately) {
            transform.position = entity.GetPosition();
            transform.rotation = Quaternion.Euler(0,_rotateAngle,0);
            _rotateAngle++;
            if (_rotateAngle == 360)
            {
                _rotateAngle = 0;
            }
        }
        
        public override void ApplyState(float deltaTime, bool immediately) {
            
        }
    }
    
}