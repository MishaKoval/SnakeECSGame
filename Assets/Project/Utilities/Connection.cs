using System.Collections;
using UnityEngine;
using NativeWebSocket;
using TMPro;

namespace Project.Utilities
{
    
    
 

    public class Connection : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        
        WebSocket websocket;

        // Start is called before the first frame update
        async void Awake()
        {
            websocket = new WebSocket("wss://dev.match.qubixinfinity.io/snake");

            websocket.OnOpen += () =>
            {
                Debug.Log("Connection open!");
            };

            websocket.OnError += (e) =>
            {
                Debug.Log("Error! " + e);
            };

            websocket.OnClose += (e) =>
            {
                Debug.Log("Connection closed!");
            };

            websocket.OnMessage += (bytes) =>
            {
                Debug.Log("OnMessage!");
                //Debug.Log(bytes);

                // getting the message as a string
                var message = System.Text.Encoding.UTF8.GetString(bytes);
                text.text = message;
                Debug.Log("OnMessage! " + message);
            };

            // Keep sending messages at every 0.3s
            //InvokeRepeating("SendWebSocketMessage", 0.0f, 0.3f);

            // waiting for messages
            await websocket.Connect();
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(2.0f);
            
            TestCreate();
        }

        [ContextMenu("TESTCreate")]
        private void TestCreate()
        {
            SendWebSocketMessage(@"
                {
                ""type"": ""create-game""
                }");
        }

        void Update()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            websocket.DispatchMessageQueue();
#endif
        }

        public async void SendWebSocketMessage(string message)
        {
            if (websocket.State == WebSocketState.Open)
            {
                await websocket.SendText(message);

                // Sending bytes
                //await websocket.Send(new byte[] { 10, 20, 30 });

                // Sending plain text
                //await websocket.SendText("plain text message");
            }
        }

        private async void OnApplicationQuit()
        {
            await websocket.Close();
        }

    }
    
    //todo JSON parsing & classes for parsing
    
    /*public class WebSocketUtility
    {
        private const string CreateGameRequest = @"
                {
                ""type"": ""create-game""
                }";

        private static string GetEndGameRequest(int gameId)
        {
            return $@"
                {{
                    ""type"": ""end-game"",
                    ""payload"": {{
                        ""game_id"": {gameId}
                    }}
                }}";
        }

        public static async Task<string> TestCreateGame()
        {
            return await TestWebSocket(CreateGameRequest);
        }
        
        public static async Task<string> TestEndGame()
        {
            return await TestWebSocket(GetEndGameRequest(1020));
        }

        private static async Task<string> TestWebSocket(string request)
        {
            using var ws = new ClientWebSocket();
            await ws.ConnectAsync(new Uri("wss://dev.match.qubixinfinity.io/snake"), CancellationToken.None);
            if (ws.State == WebSocketState.Open)
            {
                await ws.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(request)),WebSocketMessageType.Text,true,CancellationToken.None);
                ArraySegment<byte> bytesReceived = new ArraySegment<byte>(new byte[1024]);
                WebSocketReceiveResult result = await ws.ReceiveAsync(bytesReceived, CancellationToken.None);
                if (bytesReceived.Array != null)
                    return Encoding.UTF8.GetString(bytesReceived.Array, 0, result.Count);
            }
            return null;
        }
    }*/
}