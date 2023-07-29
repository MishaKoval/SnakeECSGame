using ME.ECS;
using NativeWebSocket;
using Project.Utilities;
using Newtonsoft.Json;
using Project.Components;
using Project.Markers.NetworkMarkers;
using UnityEngine;

namespace Project.Features.WebSocketNetwork.Modules {
    using Features;

#if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class WebSocketModule : IModule, IUpdate
    {
        public World world { get; set; }
        
        private WebSocketNetworkFeature feature;
        
        private WebSocket websocket;

        private int gameId;
        
        private async void SendWebSocketMessage(string message)
        {
            if (websocket.State == WebSocketState.Open)
            {
                await websocket.SendText(message);
            }
        }

        public void SendStartGameRequest()
        {
            SendWebSocketMessage(JsonConvert.SerializeObject(new ServerRequests.CreateGameRequest()));
        }

        void IModuleBase.OnConstruct() {
            feature = world.GetFeature<WebSocketNetworkFeature>();
            websocket = new WebSocket(feature.webSocketUrl);
            
            websocket.OnOpen += () =>
            {
                world.AddMarker(new NetworkInitialized());
                //world.RemoveSharedData<GamePaused>();
                //Debug.Log("Remove shared");
                //SendWebSocketMessage(JsonConvert.SerializeObject(new ServerRequests.CreateGameRequest()));
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
                var message = System.Text.Encoding.UTF8.GetString(bytes);
                var a = JsonConvert.DeserializeObject<ServerRequests.ResponseType>(message);
                switch (a.type)
                {
                    case ServerRequests.gameCreatedResponce:
                        gameId = JsonConvert.DeserializeObject<ServerRequests.CreateGameServerResponse>(message).payload.id;
                        world.AddMarker(new GameCreated());
                        break;
                    case ServerRequests.gameEndedResponce:
                        break;
                    case ServerRequests.errorResponce:
                        break;
                    default:
                        Debug.Log("UnexpectedResponce!");
                        break;
                }
                Debug.Log(message);
            };
            websocket.Connect();
        }
        
        void IModuleBase.OnDeconstruct() {}

        void IUpdate.Update(in float deltaTime)
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            websocket.DispatchMessageQueue();
#endif
        }
        
    }
    
}
