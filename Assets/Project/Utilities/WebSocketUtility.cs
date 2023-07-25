using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Utilities
{
    
    //todo JSON parsing & classes for parsing
    
    public class WebSocketUtility
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
    }
}