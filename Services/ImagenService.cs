using System;
using System.IO;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Raist.Models;

namespace Raist.Services.Helpers {
    public class ImagenService : ControllerBase {

        private static String accessKey = "";
        private static String accessSecret = "";
        private static String bucket = "fisionatbucket";


        private readonly IConfiguration _configuration;

        public ImagenService (IConfiguration configuration) {
            _configuration = configuration;

        }

        public static async Task<UploadPhotoModel> UploadObject (IFormFile file) {
            // connecting to the client
            // var accessKey = _configuration.GetSection ("AppSettings").GetValue<string> ("AWSAccessKey");
            // var accessSecret = _configuration.GetSection ("AppSettings").GetValue<string> ("AWSSecretKey");

            var client = new AmazonS3Client (accessKey, accessSecret, Amazon.RegionEndpoint.USWest2);

            // get the file and convert it to the byte[]
            byte[] fileBytes = new Byte[file.Length];
            file.OpenReadStream ().Read (fileBytes, 0, Int32.Parse (file.Length.ToString ()));

            // create unique file name for prevent the mess
            var fileName = Guid.NewGuid () + file.FileName;

            PutObjectResponse response = null;

            using (var stream = new MemoryStream (fileBytes)) {
                var request = new PutObjectRequest {
                BucketName = bucket,
                Key = fileName,
                InputStream = stream,
                ContentType = file.ContentType,
                CannedACL = S3CannedACL.PublicRead,
                };

                response = await client.PutObjectAsync (request);
            };

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK) {

                return new UploadPhotoModel {
                Success = true,
                FileName = fileName,
                BucketName = bucket
                };
            } else {

                return new UploadPhotoModel {
                    Success = false,
                        FileName = fileName
                };
            }
        }

        public static async Task<UploadPhotoModel> RemoveObject (String fileName) {

            // var accessKey = _configuration.GetSection ("AppSettings").GetValue<string> ("AWSAccessKey");
            // var accessSecret = _configuration.GetSection ("AppSettings").GetValue<string> ("AWSSecretKey");
            var client = new AmazonS3Client (accessKey, accessSecret, Amazon.RegionEndpoint.EUCentral1);

            var request = new DeleteObjectRequest {
                BucketName = bucket,
                Key = fileName
            };

            var response = await client.DeleteObjectAsync (request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK) {
                return new UploadPhotoModel {
                Success = true,
                FileName = fileName

                };
            } else {
                return new UploadPhotoModel {
                    Success = false,
                        FileName = fileName,

                };
            }
        }

    }
}