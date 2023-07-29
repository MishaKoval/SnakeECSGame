using ME.ECS;
using Project.Markers.NetworkMarkers;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Utilities
{
    [RequireComponent(typeof(Button))]
    public class RestartGameBtn : MonoBehaviour
    {
        [SerializeField] private GlobalEvent restartGameEvent;
        
        private Button restartBtn;
        
        private void OnRestartBtnClick()
        {
            Worlds.currentWorld.AddMarker(new GameRestartedMarker());
            restartGameEvent.Execute();
        }
        
        private void Awake()
        {
            restartBtn = GetComponent<Button>();
        }

        private void Start()
        {
            restartBtn.onClick.AddListener(OnRestartBtnClick);
        }
        
        private void OnDestroy()
        {
            restartBtn.onClick.RemoveListener(OnRestartBtnClick);
        }
    }
}
