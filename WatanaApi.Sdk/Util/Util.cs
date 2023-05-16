using System;
using System.IO.Compression;
using Newtonsoft.Json;
using RestSharp;

namespace WatanaApi.Sdk.Util
{
    public static class Util
    {

        public static string Request(Security.Authentication authentication, object data)
        {

            try
            {
                var uri = new Uri(authentication.url);
                var client = new RestClient($"{uri.Scheme}://{uri.Authority}/");

                RestSharp.RestRequest request = new RestRequest();
                request = new RestRequest(uri.AbsolutePath, Method.Post);

                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", authentication.token);
                request.AddJsonBody(JsonConvert.SerializeObject(data));
                var response = client.Execute(request);
                return response.Content;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public static byte[] Zip(byte[] content_unziped, string extension = "", string filename = "")
        {
            if (filename == "")
                filename = Guid.NewGuid().ToString();
            using (var compressedFileStream = new MemoryStream())
            {
                //Create an archive and store the stream in memory.
                using (var zipArchive = new ZipArchive(compressedFileStream, ZipArchiveMode.Create, false))
                {
                    var zipEntry = zipArchive.CreateEntry($"{filename}${extension}");

                    //Get the stream of the attachment
                    using (var originalFileStream = new MemoryStream(content_unziped))
                    using (var zipEntryStream = zipEntry.Open())
                    {
                        //Copy the attachment stream to the zip entry stream
                        originalFileStream.CopyTo(zipEntryStream);
                    }
                }

                return compressedFileStream.ToArray();
            }
        }

        public static byte[] Zip(FileStream file, string extension = "", string filename = "")
        {
            var content_unziped = StreamToBytes(file);
            if (filename == "")
                filename = Guid.NewGuid().ToString();
            using (var compressedFileStream = new MemoryStream())
            {
                //Create an archive and store the stream in memory.
                using (var zipArchive = new ZipArchive(compressedFileStream, ZipArchiveMode.Create, false))
                {
                    var zipEntry = zipArchive.CreateEntry($"{filename}${extension}");

                    //Get the stream of the attachment
                    using (var originalFileStream = new MemoryStream(content_unziped))
                    using (var zipEntryStream = zipEntry.Open())
                    {
                        //Copy the attachment stream to the zip entry stream
                        originalFileStream.CopyTo(zipEntryStream);
                    }
                }

                return compressedFileStream.ToArray();
            }
        }

        public static byte[] UnZip(byte[] content_ziped)
        {
            ZipArchive archive;
            try
            {
                archive = new ZipArchive(new MemoryStream(content_ziped));
            }
            catch (Exception ex)
            {
                throw new Exception("ZIP no válido - " + ex.Message);
            }

            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                var stream = entry.Open();
                try
                {
                    return StreamToBytes(stream);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error descomprimiendo - " + ex.Message);
                }
            }
            throw new Exception("Error descomprimiendo.");
        }

        public static byte[] StreamToBytes(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

    }
}

