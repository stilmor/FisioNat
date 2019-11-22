// using System;
// using System.IO;
// using Amazon.Runtime.Internal.Util;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using Newtonsoft.Json;

// namespace Raist.Controllers {
//     public class SnsController : ControllerBase {

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