using System;

namespace Project.Utilities
{
    public static class ServerRequests
    {
        public const string gameCreatedResponce = "game-created";
        public const string gameEndedResponce = "game-ended";
        public const string errorResponce = "error";
        
        [Serializable] public class ResponseType
        {
            public string type;
        }
        
        [Serializable] public class CreateGameServerResponse
        {
            public CreatePayload payload;
        }
        
        [Serializable] public class EndGameServerResponse
        {
            public EndPayload payload;
        }
        
        [Serializable] public class CreateGameRequest { public string type = "create-game"; }
        
        [Serializable] public class EndGameRequest
        {
            public string type = "end-game";
            public EndPayload payload;
        }
        
        [Serializable] public class CollectAppleRequest
        {
            public string type = "collect-apple";
            public CollectPayload payload;
        }
        
        [Serializable] 
        public class EndPayload
        {
            public int game_id;
        }
        
        [Serializable]
        public class CollectPayload
        {
            public int appleCount;
            public int snakeLength;
            public int game_id;
        }
        
        [Serializable]
        public class CreatePayload
        {
            public string clientAddress;
            public string startAt;
            public string finishAt;
            public int id;
            public int collectedApples;
            public int snakeLength;
            public string created_at;
            public string updated_at;
        }
    }
}