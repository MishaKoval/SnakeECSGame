using ME.ECS;
using Project.Markers.InputMarkers;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Utilities
{
    public class UIInputButtons : MonoBehaviour
    {
        [SerializeField] private GlobalEvent gameCreatedEvent;

        [SerializeField] private GlobalEvent gameOverEvent;
        
        [SerializeField] private Button upBtn;
        
        [SerializeField] private Button downBtn;
        
        [SerializeField] private Button leftBtn;
        
        [SerializeField] private Button rightBtn;

        private void Start()
        {
            gameCreatedEvent.Subscribe(EnableButtons);
            gameOverEvent.Subscribe(DisableButtons);
            leftBtn.onClick.AddListener(LeftBtnClick);
            rightBtn.onClick.AddListener(RightBtnClick);
            upBtn.onClick.AddListener(UpBtnClick);
            downBtn.onClick.AddListener(DownBtnClick);
        }

        private void OnDestroy()
        {
            gameCreatedEvent.Unsubscribe(EnableButtons);
            gameOverEvent.Unsubscribe(DisableButtons);
            leftBtn.onClick.RemoveListener(LeftBtnClick);
            rightBtn.onClick.RemoveListener(RightBtnClick);
            upBtn.onClick.RemoveListener(UpBtnClick);
            downBtn.onClick.RemoveListener(DownBtnClick);
        }

        private void EnableButtons(in Entity _)
        {
            leftBtn.gameObject.SetActive(true);
            rightBtn.gameObject.SetActive(true);
            upBtn.gameObject.SetActive(true);
            downBtn.gameObject.SetActive(true);
        }
        
        private void DisableButtons(in Entity entity)
        {
            leftBtn.gameObject.SetActive(false);
            rightBtn.gameObject.SetActive(false);
            upBtn.gameObject.SetActive(false);
            downBtn.gameObject.SetActive(false);
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