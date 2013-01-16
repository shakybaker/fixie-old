using Microsoft.AspNet.SignalR.Hubs;
using System;

namespace Fixie.Hubs
{
    public class BoardHub : Hub
    {
        public void MovedCard(int cardId, string laneId, int position, string activity)
        {
            // Call the broadcastMessage method to update clients.
            Clients.Others.moveCard(new BasicJsonModel {cardId = cardId, laneId = laneId, position = position});
            Clients.All.broadcastActivity(activity);
        }

        public void SendActivity(string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastActivity(message);
        }

        public class BasicJsonModel
        {
            public int cardId { get; set; }
            public string laneId { get; set; }
            public int position { get; set; }
        }
    }
}