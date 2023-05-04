using Azure.Storage.Blobs;
using System;
using System.IO;

namespace BlobStorageAccess
{
    public class BlobStorageProvider
    {
        public static void UploadImg(string name, string format, string path, MemoryStream file)
        {
            //https://azban7blob7storage.blob.core.windows.net/orders-images

            var connectionString = "DefaultEndpointsProtocol=https;AccountName=azban7blob7storage;AccountKey=wAacTP913uuKcGssE/eix/unZ15UHWvVioQ4U+W+YCUh+4bbpkGCkVuJf09OPUtHjozsMQIAij224kCCWk01gQ==;EndpointSuffix=core.windows.net";
            var containerName = "orders-images";

            var bsClient = new BlobContainerClient(connectionString, containerName);
            bsClient.UploadBlob($"{path}/{name}.{format}", file);
        }
    }
}
