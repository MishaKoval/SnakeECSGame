using ME.ECS;
using UnityEngine;

namespace Project.Utilities
{
    public class StartScreen : MonoBehaviour
    {
        [SerializeField] private GlobalEvent gameCreated;

        [SerializeField] private GlobalEvent startGameLoading;
    
        private void Start()
        {
            gameCreated.Subscribe(OnGameCreated);
            startGameLoading.Subscribe(OnGameStartLoading);
        }
    
        private void OnDestroy()
        {
            gameCreated.Unsubscribe(OnGameCreated);
            startGameLoading.Unsubscribe(OnGameStartLoading);
        }
    
        private void OnGameStartLoading(in Entity _)
        {
            gameObject.SetActive(true);
        }
        
        private void OnGameCreated(in Entity _)
        {
            gameObject.SetActive(false);
        }
    }
}
