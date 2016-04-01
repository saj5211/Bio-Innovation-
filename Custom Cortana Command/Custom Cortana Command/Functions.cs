using System;
using System.Collections.Generic;
using Windows.UI.Popups;

using Windows.Storage;
using Windows.ApplicationModel;
using Windows.ApplicationModel.VoiceCommands;

using Windows.System;
using Windows.Media.SpeechRecognition;
using Windows.ApplicationModel.Activation;

namespace CustomCortanaCommands
{

    class CortanaFunctions
    {
        
        private readonly static IReadOnlyDictionary<string, Delegate> vcdLookup = new Dictionary<string, Delegate>{

            {"OpenFile", (Action)(async () => {
                StorageFile file = await Package.Current.InstalledLocation.GetFileAsync(@"Test.txt");
                await Launcher.LaunchFileAsync(file);
            })},

            {"OpenWebsite", (Action)(async () => { 
                 Uri website = new Uri(@"http://www.reddit.com");
                 await Launcher.LaunchUriAsync(website);
             })},
        };

        public static async void RegisterVCD()
        {
            StorageFile vcd = await Package.Current.InstalledLocation.GetFileAsync(
                @"Custom_Commands.xml");

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
