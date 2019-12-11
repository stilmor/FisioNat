using System;
using System.Collections.Generic;
using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Raist.Controllers {

    //[Authorize]
    [Route ("/Sns")]
    public class SnsController : AmazonWebServiceResponse {

        public static String accessKey = "";
        public static String accessSecret = "";

        private readonly IConfiguration _configuration;
        public SnsController (IConfiguration configuration) {
            _configuration = configuration;
        }

        [HttpGet]
        public void SNSSubscriptionPost () {

            var snsClient = new AmazonSimpleNotificationServiceClient (Amazon.RegionEndpoint.USEast2);
            string nombreTopic = "nuevo Tema";

            var nuevoTopic = new CreateTopicRequest {

                Name = nombreTopic,
                Attributes = new Dictionary<string, string> () { { accessKey, accessSecret }
                }
            };

            // var a = snsClient.CreateTopicAsync

            // String topicArn = "arn:aws:sns:us-west-2:433048134094:mytopic";
            // Console.WriteLine("va bien");
            // String msg = "If you receive this message, publishing a message to an Amazon SNS topic works.";
            // PublishRequest publishRequest = new PublishRequest(topicArn, msg);
            // Console.WriteLine("va bien 2");
            // var publishResponse = await snsClient.PublishAsync(publishRequest);
            // Console.WriteLine("va bien 3");

            // // Print the MessageId of the published message.
            // Console.WriteLine ("MessageId: " + publishResponse.MessageId);
            // await snsClient.PublishAsync(publishRequest);
        }

        // Publish a message to an Amazon SNS topic.

        // [HttpPost]
        // public String SNSSubscriptionPost (String id = "") {
        //     return "";
        // }

        // public static void mandarCorreo (string email) {
        //     {
        //         var sns = new AmazonSimpleNotificationServiceClient ();
        //         string emailAddress = email;

        //            var  topicArn = sns.CreateTopic( new CreateTopicRequest{
        //                 Name ="SampleSNSTopic"
        //             }).TopicArn;
        //     }
        // }
    }

}

// using System;
// using System.IO;
// using Amazon.Runtime.Internal.Util;
// using Microsoft.Extensions.Logging;
// using Newtonsoft.Json;
// using Amazon.SimpleNotificationService;
// using Amazon.SimpleNotificationService.Model;

// namespace Raist.Controllers {
//     public class SnsController  {

//         //[Authorize]
//         [Route ("/Sns")]

//         [HttpPost]1
//         public String SNSSubscriptionPost (String id = "") {
//             try {
//                 var jsonData = "";
//                 Stream req = Request.InputStream;
//                 req.Seek (0, System.IO.SeekOrigin.Begin);
//                 String json = new StreamReader (req).ReadToEnd ();
//                 var sm = Amazon.SimpleNotificationService.Util.Message.ParseMessage (json);
//                 if (sm.Type.Equals ("SubscriptionConfirmation")) //for confirmation
//                 {
//                     Logger.Info ("Received Confirm subscription request");
//                     if (!string.IsNullOrEmpty (sm.SubscribeURL)) {
//                         var uri = new Uri (sm.SubscribeURL);
//                         Logger.Info ("uri:" + uri.ToString ());
//                         var baseUrl = uri.GetLeftPart (System.UriPartial.Authority);
//                         var resource = sm.SubscribeURL.Replace (baseUrl, "");
//                         var response = new RestClient {
//                             BaseUrl = new Uri (baseUrl),
//                         }.Execute (new RestRequest {
//                             Resource = resource,
//                                 Method = Method.GET,
//                                 RequestFormat = RestSharp.DataFormat.Xml
//                         });
//                     }
//                 } else // For processing of messages
//                 {
//                     logger.Info ("Message received from SNS:" + sm.TopicArn);
//                     dynamic message = JsonConvert.DeserializeObject (sm.MessageText);
//                     logger.Info ("EventTime : " + message.detail.eventTime);
//                     logger.Info ("EventName : " + message.detail.eventName);
//                     logger.Info ("RequestParams : " + message.detail.requestParameters);
//                     logger.Info ("ResponseParams : " + message.detail.responseElements);
//                     logger.Info ("RequestID : " + message.detail.requestID);
//                 }
//                 //do stuff
//                 return "Success";
//             } catch (Exception ex) {
//                 logger.Info ("failed");
//                 return "";
//             }
//         }
//     }
// }