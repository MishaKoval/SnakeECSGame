using ME.ECS;
using UnityEngine;

namespace Project.Utilities
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private GlobalEvent gameOver;
        
        [SerializeField] private GlobalEvent gameRestarted;
    
        private void OnGameRestarted(in Entity entity)
        {
            gameObject.SetActive(false);
        }
    
        private void OnGameOver(in Entity _)
        {
            gameObject.SetActive(true);
        }
        
        private void Start()
        {
            gameOver.Subscribe(OnGameOver);
            gameRestarted.Subscribe(OnGameRestarted);
            gameObject.SetActive(false);
        }
        
        private void OnDestroy()
        {
            gameOver.Unsubscribe(OnGameOver);
            gameRestarted.Unsubscribe(OnGameRestarted);
        }
    }
}
