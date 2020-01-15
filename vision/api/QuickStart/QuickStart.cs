// Copyright(c) 2017 Google Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License. You may obtain a copy of
// the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
// WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
// License for the specific language governing permissions and limitations under
// the License.

// [START vision_quickstart]

using Cloudmersive.APIClient.NET.OCR.Api;
using Cloudmersive.APIClient.NET.OCR.Client;
using Cloudmersive.APIClient.NET.OCR.Model;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Vision.V1;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GoogleCloudSamples
{
    public class QuickStart
    {
        //////public static void Main(string[] args)
        //////{
        //////    // Configure API key authorization: Apikey
        //////    Configuration.Default.AddApiKey("Apikey", "fff352e6-c321-423b-b415-f32becb7bcc9");
        //////    // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
        //////    // Configuration.Default.AddApiKeyPrefix("Apikey", "Bearer");

        //////    var apiInstance = new ImageOcrApi();
        //////    var imageFile = File.OpenRead("11.jpg"); // System.IO.Stream | Image file to perform OCR on.  Common file formats such as PNG, JPEG are supported.
        //////    var recognitionMode = "Basic";  // string | Optional; possible values are 'Basic' which provides basic recognition and is not resillient to page rotation, skew or low quality images uses 1-2 API calls; 'Normal' which provides highly fault tolerant OCR recognition uses 14-16 API calls; and 'Advanced' which provides the highest quality and most fault-tolerant recognition uses 28-30 API calls.  Default recognition mode is 'Advanced' (optional) 
        //////    var language = "VIE";  //ENG VIE string | Optional, language of the input document, default is English (ENG).  Possible values are ENG (English), ARA (Arabic), ZHO (Chinese - Simplified), ZHO-HANT (Chinese - Traditional), ASM (Assamese), AFR (Afrikaans), AMH (Amharic), AZE (Azerbaijani), AZE-CYRL (Azerbaijani - Cyrillic), BEL (Belarusian), BEN (Bengali), BOD (Tibetan), BOS (Bosnian), BUL (Bulgarian), CAT (Catalan; Valencian), CEB (Cebuano), CES (Czech), CHR (Cherokee), CYM (Welsh), DAN (Danish), DEU (German), DZO (Dzongkha), ELL (Greek), ENM (Archaic/Middle English), EPO (Esperanto), EST (Estonian), EUS (Basque), FAS (Persian), FIN (Finnish), FRA (French), FRK (Frankish), FRM (Middle-French), GLE (Irish), GLG (Galician), GRC (Ancient Greek), HAT (Hatian), HEB (Hebrew), HIN (Hindi), HRV (Croatian), HUN (Hungarian), IKU (Inuktitut), IND (Indonesian), ISL (Icelandic), ITA (Italian), ITA-OLD (Old - Italian), JAV (Javanese), JPN (Japanese), KAN (Kannada), KAT (Georgian), KAT-OLD (Old-Georgian), KAZ (Kazakh), KHM (Central Khmer), KIR (Kirghiz), KOR (Korean), KUR (Kurdish), LAO (Lao), LAT (Latin), LAV (Latvian), LIT (Lithuanian), MAL (Malayalam), MAR (Marathi), MKD (Macedonian), MLT (Maltese), MSA (Malay), MYA (Burmese), NEP (Nepali), NLD (Dutch), NOR (Norwegian), ORI (Oriya), PAN (Panjabi), POL (Polish), POR (Portuguese), PUS (Pushto), RON (Romanian), RUS (Russian), SAN (Sanskrit), SIN (Sinhala), SLK (Slovak), SLV (Slovenian), SPA (Spanish), SPA-OLD (Old Spanish), SQI (Albanian), SRP (Serbian), SRP-LAT (Latin Serbian), SWA (Swahili), SWE (Swedish), SYR (Syriac), TAM (Tamil), TEL (Telugu), TGK (Tajik), TGL (Tagalog), THA (Thai), TIR (Tigrinya), TUR (Turkish), UIG (Uighur), UKR (Ukrainian), URD (Urdu), UZB (Uzbek), UZB-CYR (Cyrillic Uzbek), VIE (Vietnamese), YID (Yiddish) (optional) 
        //////    var preprocessing = "Auto";  // string | Optional, preprocessing mode, default is 'Auto'.  Possible values are None (no preprocessing of the image), and Auto (automatic image enhancement of the image before OCR is applied; this is recommended). (optional) 

        //////    try
        //////    {
        //////        // Convert a scanned image into text
        //////        ImageToLinesWithLocationResult result2 = apiInstance.ImageOcrImageLinesWithLocation(imageFile, language, preprocessing);

        //////        ImageToTextResponse result = apiInstance.ImageOcrPost(imageFile, recognitionMode, language, preprocessing);
        //////        //Debug.WriteLine(result);
        //////    }
        //////    catch (Exception e)
        //////    {
        //////        //Debug.Print("Exception when calling ImageOcrApi.ImageOcrPost: " + e.Message);
        //////    }
        //////}

        /// ////////////////////////////////////////////////////


        public static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"C:\goo-token\mapdemo-b25d5819bbdb.json");

            //GoogleCredential credential = GoogleCredential.GetApplicationDefault();

            string value = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");


            // If you don't specify credentials when constructing the client, the
            // client library will look for credentials in the environment.
            var credential = GoogleCredential.GetApplicationDefault();
            //var storage =  StorageClient.Create(credential);
            //// Make an authenticated API request.
            //var buckets = storage.ListBuckets(projectId);
            //foreach (var bucket in buckets)
            //{
            //    Console.WriteLine(bucket.Name);
            //}












            var client = ImageAnnotatorClient.Create();
            //// Load the image file into memory
            var image = Image.FromFile("wakeupcat.jpg");
            //// Performs label detection on the image file
            var response = client.DetectText(image);
            string s = response[0].Description;

            ////// Instantiates a client
            ////var client = ImageAnnotatorClient.Create();
            ////// Load the image file into memory
            ////var image = Image.FromFile("wakeupcat.jpg");
            ////// Performs label detection on the image file
            ////var response = client.DetectLabels(image);
            ////foreach (var annotation in response)
            ////{
            ////    if (annotation.Description != null)
            ////        Console.WriteLine(annotation.Description);
            ////}

            Console.WriteLine("Done ..");
            Console.ReadKey();
        }
    }
}
// [END vision_quickstart]
