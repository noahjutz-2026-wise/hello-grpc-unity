using System;
using UnityEngine;
using Grpc.Net.Client;
using GrpcUnity;
using Cysharp.Net.Http;

namespace DefaultNamespace
{
    public class App : MonoBehaviour
    {
        public async void Start()
        {
            Debug.Log("App Start");
            var handler = new YetAnotherHttpHandler { Http2Only = true };
            var channel = GrpcChannel.ForAddress("http://localhost:50051",
                new GrpcChannelOptions { HttpHandler = handler });
            var client = new GreeterService.GreeterServiceClient(channel);
            var req = new SayHelloRequest { Name = "Hello Grpc Unity v2" };
            var response = await client.SayHelloAsync(req);
            Debug.Log(response.ToString());
        }
    }
}