// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}
using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace Live360.Demo
{
    public static class ImageReceived
    {
        [FunctionName("ImageReceived")]
        public static void Run(
            [EventGridTrigger] 
            EventGridEvent eventGridEvent,
            ILogger log)
        {
            dynamic data = eventGridEvent.Data;

            var uri = new Uri((string)data.url);
            var image = uri.PathAndQuery;

            // 1) TODO: Save Input Data to Cosmos

            // 2) Find Faces

            // Take up some memory
            var bytes = new byte[30_000_000];

            log.LogInformation("START Image: {ImageId}, {Url}", eventGridEvent.Id, uri.ToString());
            // Simulate retrieving and processing the image
            Thread.Sleep(Random.Shared.Next(10_000, 30_000));

            // fake results
            var faceCount = Random.Shared.Next(0, 5);

            log.LogInformation("END   Image: {ImageId}, {Url} NumFaces: {FaceCount}",
                eventGridEvent.Id, uri.ToString(), faceCount);

            // 3) TODO: Save the results
            
            // 4) TODO: Send notifications
        }
    }
}
