using System;
using Amazon.SimpleNotificationService.Model;

namespace Raist.Models {
    public class EmailSns {
        PublishRequest request = new PublishRequest {
            Message = $"Test at {DateTime.UtcNow.ToLongDateString()}",
            TopicArn = "arn:aws:sns:us-east-1:433048134094:EmailFisioNat",
        };

        // var response = await _simpleNotificationService.PublishAsync(request);
    }
}