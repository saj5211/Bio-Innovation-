using System;
using System.Collections.Generic;
using Windows.UI.Popups;

using Windows.Storage;
using Windows.ApplicationModel;
using Windows.ApplicationModel.VoiceCommands;

using Windows.System;
using Windows.Media.SpeechRecognition;
using Windows.ApplicationModel.Activation;


namespace Cortana_Arduino_Code
{
    class Functions
    {
        private readonly static IReadOnlyDictionary<string, Delegate> vcdLookup = new Dictionary<string, Delegate>{

           
            {"Massage", (Action)(async () => {
               Uri website = new Uri(@"http://www.apple.com/");
                 await Launcher.LaunchUriAsync(website);
                
            })},

            {"Move", (Action)(async () => {
                 Uri website = new Uri(@"http://www.microsoft.com");
                 await Launcher.LaunchUriAsync(website);
             })},
        };

        /*
        Register Custom Cortana Commands from VCD file
        */
        public static async void RegisterVCD()
        {
            StorageFile vcd = await Package.Current.InstalledLocation.GetFileAsync(
                @"Commands.xml");

            await VoiceCommandDefinitionManager
                .InstallCommandDefinitionsFromStorageFileAsync(vcd);
        }
        public static void RunCommand(VoiceCommandActivatedEventArgs cmd)
        {
            SpeechRecognitionResult result = cmd.Result;
            string commandName = result.RulePath[0];
            vcdLookup[commandName].DynamicInvoke();
        }
    }
}
