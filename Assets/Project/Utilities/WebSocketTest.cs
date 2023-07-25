using UnityEngine;

namespace Project.Utilities
{
    public class WebSocketTest : MonoBehaviour
    {
        [ContextMenu("TESTCreate")]
        private async void TestCreate()
        {
            Debug.Log(await WebSocketUtility.TestCreateGame());
        }
        
        [ContextMenu("TESTEnd")]
        private async void TestEnd()
        {
            Debug.Log(await WebSocketUtility.TestEndGame());
        }
    }
}