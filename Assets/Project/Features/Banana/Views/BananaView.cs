using System;
using System.Globalization;
using ME.ECS;
using Project.Features.Banana.Components;
using TMPro;
using UnityEngine;

namespace Project.Features.Banana.Views {
    
    using ME.ECS.Views.Providers;
    
    public class BananaView : MonoBehaviourView
    {
        [SerializeField] private float rotateSpeed;
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private Transform bananaModel;
        
        public override bool applyStateJob => true;

        private float _rotateAngle;

        public override void OnInitialize() {
            
        }
        
        public override void OnDeInitialize() {
            
        }
        
        public override void ApplyStateJob(UnityEngine.Jobs.TransformAccess transform, float deltaTime, bool immediately)
        {
            transform.position = entity.GetPosition();
           
        }
        
        public override void ApplyState(float deltaTime, bool immediately) {
            timerText.text = Math.Round(entity.Get<IsBanana>().LifeTime,1).ToString(CultureInfo.CurrentCulture);
            bananaModel.rotation = Quaternion.Euler(0,_rotateAngle,0);
            _rotateAngle+=  rotateSpeed * deltaTime;
            if (_rotateAngle >= 360)
            {
                _rotateAngle = 0;
            }
        }
    }
    
}