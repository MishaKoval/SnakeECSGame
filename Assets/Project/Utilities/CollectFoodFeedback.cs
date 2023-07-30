using System.Collections;
using ME.ECS;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Project.Utilities
{
    public class CollectFoodFeedback : MonoBehaviour
    {
        private const float defaultBloomValue = 0.25f;
        
        private const float collectBloomValue = 1.25f;
        
        [SerializeField] private GlobalEvent collectFoodEvent;

        [SerializeField] private VolumeProfile volumeProfile;

        [SerializeField] private AudioSource _audioSource;

        [SerializeField] private float waitBloomTime;

        private WaitForSeconds _waitBloom;
        
        private void FoodCollectFeedback(in Entity entity)
        {
            _audioSource.Play();
            ChangeBloomValue(collectBloomValue);
            StartCoroutine(WaitBloom());
        }

        private void ChangeBloomValue(float value)
        {
            if (volumeProfile.TryGet(out Bloom bloom))
            {
                bloom.intensity.value = value;
            }
        }

        private IEnumerator WaitBloom()
        {
            yield return _waitBloom;
            ChangeBloomValue(defaultBloomValue);
        }

        private void Awake()
        {
            _waitBloom = new WaitForSeconds(waitBloomTime);
        }

        private void Start()
        {
            ChangeBloomValue(defaultBloomValue);
            collectFoodEvent.Subscribe(FoodCollectFeedback);
        }
        private void OnDestroy()
        {
            ChangeBloomValue(defaultBloomValue);
            collectFoodEvent.Unsubscribe(FoodCollectFeedback);
        }
    }
}
