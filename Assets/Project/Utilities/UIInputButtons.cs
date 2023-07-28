using ME.ECS;
using Project.Markers;
using Project.Markers.InputMarkers;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Utilities
{
    public class UIInputButtons : MonoBehaviour
    {
        [SerializeField] private Button upBtn;
        
        [SerializeField] private Button downBtn;
        
        [SerializeField] private Button leftBtn;
        
        [SerializeField] private Button rightBtn;

        private void Start()
        {
            leftBtn.onClick.AddListener(LeftBtnClick);
            rightBtn.onClick.AddListener(RightBtnClick);
            upBtn.onClick.AddListener(UpBtnClick);
            downBtn.onClick.AddListener(DownBtnClick);
        }
        
        private void OnDestroy()
        {
            leftBtn.onClick.RemoveListener(LeftBtnClick);
            rightBtn.onClick.RemoveListener(RightBtnClick);
            upBtn.onClick.RemoveListener(UpBtnClick);
            downBtn.onClick.RemoveListener(DownBtnClick);
        }
        
        private void LeftBtnClick() {
            Worlds.currentWorld.AddMarker(new LeftKeyMarker());
        }
        
        private void RightBtnClick() {
            Worlds.currentWorld.AddMarker(new RightKeyMarker());
        }
        
        private void UpBtnClick() {
            Worlds.currentWorld.AddMarker(new UpKeyMarker());
        }
        
        private void DownBtnClick() {
            Worlds.currentWorld.AddMarker(new DownKeyMarker());
        }
    }
}