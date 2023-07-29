using ME.ECS;
using UnityEngine;

namespace Project.Utilities
{
    public class StartScreen : MonoBehaviour
    {
        [SerializeField] private GlobalEvent gameCreated;
    
        private void Start()
        {
            gameCreated.Subscribe(OnGameCreated);
        }
    
        private void OnDestroy()
        {
            gameCreated.Unsubscribe(OnGameCreated);
        }
    
        private void OnGameCreated(in Entity _)
        {
            gameObject.SetActive(false);
        }
    }
}
