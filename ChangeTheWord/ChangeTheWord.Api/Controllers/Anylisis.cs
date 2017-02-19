using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Http;
using ChangeTheWord.Api.Models;
using Microsoft.CognitiveServices.SpeechRecognition;
using Swashbuckle.Swagger.Annotations;

namespace ChangeTheWord.Api.Controllers
{
    public class AnalysisController : ApiController
    {
        [SwaggerOperation("GetSugestions")]
        public Suggestions Get()
        {
            this.CreateDataRecoClient();
            this.SendAudioHelper(@"C:\Source\batman.wav");
            var replacements = new List<ReplacementWord>
            {
                new ReplacementWord()
                {
                    Original = "Hello",
                    Replacements = new List<string>
                    {
                        "Greatings"
                    }
                }
            };

            var mostused = new List<string>
            {
                "to",
                "the",
                "of"
            };
            return new Suggestions()
            {
                ReplacementWords = replacements,
                MostUsedWords = mostused
            };
        }

        private DataRecognitionClient dataClient;

        private readonly SpeechRecognitionMode Mode = SpeechRecognitionMode.LongDictation;
        private readonly string SubscriptionKey = @"d23c0a4dd1e7492e902152fc5254add3";

        private void SendAudioHelper(string wavFileName)
        {
            using (var fileStream = new FileStream(wavFileName, FileMode.Open, FileAccess.Read))
            {
                var bytesRead = 0;
                var buffer = new byte[1024];

                try
                {
                    do
                    {
                        // Get more Audio data to send into byte buffer.
                        bytesRead = fileStream.Read(buffer, 0, buffer.Length);

                        // Send of audio data to service. 
                        dataClient.SendAudio(buffer, bytesRead);
                    } while (bytesRead > 0);
                }
                finally
                {
                    // We are done sending audio.  Final recognition results will arrive in OnResponseReceived event call.
                    dataClient.EndAudio();
                }
            }
        }

        private void CreateDataRecoClient()
        {
            dataClient = SpeechRecognitionServiceFactory.CreateDataClient(
                Mode,
                "en-US",
                SubscriptionKey);

            // Event handlers for speech recognition results
            dataClient.OnResponseReceived += this.OnDataDictationResponseReceivedHandler;
        }

        private void OnDataDictationResponseReceivedHandler(object sender, SpeechResponseEventArgs e)
        {
            Console.WriteLine("--- OnDataDictationResponseReceivedHandler ---");

            this.WriteResponseResult(e);
        }

        private void WriteResponseResult(SpeechResponseEventArgs e)
        {
            if (e.PhraseResponse.Results.Length == 0)
            {
                Console.WriteLine("No phrase response is available.");
            }
            else
            {
                Console.WriteLine("********* Final n-BEST Results *********");
                for (int i = 0; i < e.PhraseResponse.Results.Length; i++)
                {
                    Console.WriteLine(
                        "[{0}] Confidence={1}, Text=\"{2}\"",
                        i,
                        e.PhraseResponse.Results[i].Confidence,
                        e.PhraseResponse.Results[i].DisplayText);
                }

                Console.WriteLine();
            }
        }
    }
}