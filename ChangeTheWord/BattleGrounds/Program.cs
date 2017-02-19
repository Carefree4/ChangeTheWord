using System;
using System.CodeDom;
using System.IO;
using System.Windows.Forms;
using Microsoft.CognitiveServices.SpeechRecognition;

namespace BattleGrounds
{
    internal class Program
    {
        private readonly string DefaultLocale = "en-US";

        private readonly SpeechRecognitionMode Mode = SpeechRecognitionMode.LongDictation;
        private readonly string SubscriptionKey = @"d23c0a4dd1e7492e902152fc5254add3";
        private DataRecognitionClient dataClient;
        private MicrophoneRecognitionClient micClient;
        public string text;

        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Window());
        }

        public void SendAudioHelper(string wavFileName)
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

        public void CreateDataRecoClient()
        {
            dataClient = SpeechRecognitionServiceFactory.CreateDataClient(
                Mode,
                "en-US",
                SubscriptionKey);

            // Event handlers for speech recognition results
            dataClient.OnResponseReceived += OnDataDictationResponseReceivedHandler;
        }

        private void OnDataDictationResponseReceivedHandler(object sender, SpeechResponseEventArgs e)
        {
            Console.WriteLine("--- OnDataDictationResponseReceivedHandler ---");

            WriteResponseResult(e);
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
                foreach (RecognizedPhrase t in e.PhraseResponse.Results)
                {
                    text += t.DisplayText + " ";
                }

                Console.WriteLine("========================================\n" + text);
                
                var a = new Analysis();
                a.Input = text;
                var sentWords = a.ReplaceWords();
                var wordCount = a.WordCount();

            }
        }
    }
}