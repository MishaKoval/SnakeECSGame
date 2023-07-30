using System.Collections;
using ME.ECS;
using TMPro;
using UnityEngine;

namespace Project.Utilities
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private GlobalEvent gameOver;
        
        [SerializeField] private GlobalEvent gameRestarted;

        [SerializeField] private TMP_Text gameOverText;
        
        [SerializeField] private float scaleChangeTime;

        [SerializeField] private float maxTextSize;

        [SerializeField] private float minTextSize;

        private bool _isUpScale;
        
        private WaitForSeconds _scaleChangeStep;
        
        private void OnGameRestarted(in Entity entity)
        {
            gameObject.SetActive(false);
        }
    
        private void OnGameOver(in Entity _)
        {
            gameObject.SetActive(true);
        }

        private void OnEnable()
        {
            StartCoroutine(GameOverTextScaler());
        }

        private IEnumerator GameOverTextScaler()
        {
            while (true)
            {
                yield return _scaleChangeStep;
                if (_isUpScale)
                {
                    gameOverText.fontSize += 1;
                }
                else
                {
                    gameOverText.fontSize -= 1;
                }

                if (gameOverText.fontSize > maxTextSize)
                {
                    _isUpScale = false;
                }
                else
                {
                    if (gameOverText.fontSize < minTextSize)
                    {
                        _isUpScale = true;
                    }
                }
            }
        }

        private void Start()
        {
            _scaleChangeStep = new WaitForSeconds(scaleChangeTime);
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
