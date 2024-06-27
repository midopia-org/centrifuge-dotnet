using System;
using System.Threading;
using Centrifuge;

namespace Example
{
    internal class Program
    {
        private static string TOKEN = "3f3153f6-81a8-476d-9ece-93e022bafedd-e8f8ff6f-1df8-41ae-b340-2c017d0efbcb";

        public class TokenGetter : ConnectionTokenGetter
        {
            public override void GetConnectionToken(ConnectionTokenEvent e, TokenCallback cb)
            {
                cb(null, TOKEN);
            }
        }

        public class Listener : EventListener
        {
            public override void OnConnecting(Client client, ConnectingEvent e)
            {
                Console.WriteLine("onConnecting");
            }

            public override void OnConnected(Client client, ConnectedEvent e)
            {
                Console.WriteLine("onConnected");
            }

            public override void OnDisconnected(Client client, DisconnectedEvent e)
            {
                Console.WriteLine("onDisconnected");
            }

            public override void OnError(Client client, ErrorEvent e)
            {
                Console.WriteLine("onError1" + e.Error);
            }

            public override void OnMessage(Client client, MessageEvent e)
            {
                Console.WriteLine("onMessage: " + e.ToString());
            }

            public override void OnSubscribed(Client client, ServerSubscribedEvent e)
            {
                Console.WriteLine("onSubscribed");
            }

            public override void OnSubscribing(Client client, ServerSubscribingEvent e)
            {
                Console.WriteLine("onSubscribing");
            }

            public override void OnUnsubscribed(Client client, ServerUnsubscribedEvent e)
            {
                Console.WriteLine("onUnsubscribed");
            }

            public override void OnPublication(Client client, ServerPublicationEvent e)
            {
                Console.WriteLine("onPublication: " + e.ToString());
            }

            public override void OnJoin(Client client, ServerJoinEvent e)
            {
                Console.WriteLine("onJoin");
            }

            public override void OnLeave(Client client, ServerLeaveEvent e)
            {
                Console.WriteLine("onLeave");
            }
        }

        public class SubListener : SubscriptionEventListener
        {
            public override void OnPublication(Subscription sub, PublicationEvent e)
            {
                var d = System.Text.Encoding.UTF8.GetString(e.Data);
                Console.WriteLine("onPublication" + d);
            }

            public override void OnJoin(Subscription sub, JoinEvent e)
            {
                Console.WriteLine("onJoin");
            }

            public override void OnLeave(Subscription sub, LeaveEvent e)
            {
                Console.WriteLine("onLeave");
            }

            public override void OnSubscribed(Subscription sub, SubscribedEvent e)
            {
                Console.WriteLine("onSubscribed");
            }

            public override void OnUnsubscribed(Subscription sub, UnsubscribedEvent e)
            {
                Console.WriteLine("onUnsubscribed");
            }

            public override void OnSubscribing(Subscription sub, SubscribingEvent e)
            {
                Console.WriteLine("onSubscribing");
            }

            public override void OnError(Subscription sub, SubscriptionErrorEvent e)
            {
                Console.WriteLine("onError" + e.Error);
            }
        }

        public static void Main(string[] args)
        {
            Options opts = new Options()
            {
                Token = TOKEN,
                TokenGetter = new TokenGetter(),
            };

            Client client = new Client("ws://localhost:8082/connection/websocket", opts, new Listener());
            client.Connect();

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
