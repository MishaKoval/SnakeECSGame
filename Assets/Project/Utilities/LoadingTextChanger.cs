using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;

namespace Project.Utilities
{
    [RequireComponent(typeof(TMP_Text))]
    public class LoadingTextChanger : MonoBehaviour
    {
        [SerializeField] private float changeStepTime = 0.5f;

        private const string loading = "Loading";

        private StringBuilder builder = new();
    
        private TMP_Text _text;

        private WaitForSeconds changeStepWait;

        private int dotsCount = 0;
    
        private int maxDotsCount = 3;
    
        private void Awake()
        {
            changeStepWait = new WaitForSeconds(changeStepTime);
            _text = GetComponent<TMP_Text>();
        }
        private void Start()
        {
            StartCoroutine(TextChanger());
        }

        private IEnumerator TextChanger()
        {
            while (true)
            {
                yield return changeStepWait;
                dotsCount++;
                builder.Clear();
                builder.Append(loading);
                for (int i = 0; i < dotsCount; i++)
                {
                    builder.Append(".");
                }
                _text.text = builder.ToString();
                if (dotsCount >= maxDotsCount)
                {
                    dotsCount = 0;
                }
            }
        }
    }
}
