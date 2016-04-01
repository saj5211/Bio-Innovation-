using System;
using System.Collections.Generic;
using Windows.UI.Popups;
using Windows.Storage;
using Windows.ApplicationModel;
using Windows.ApplicationModel.VoiceCommands;
using Windows.Media.SpeechRecognition;
using Windows.ApplicationModel.Activation;

namespace CustomCommands
{
    class Functions
    {
        private readonly static IReadOnlyCollection<string, Delegate> vcdLookup = new Dictionary<string, Delegate>
        {
        {"Massage", (Action)(async () => {
            /*Add code for Function*/
                
            })},
        {"Moving", (Action)(async () => {

            })},
};
        public static async void RegisterVCD()
        {
            StorageFile vcd = await Package.Current.InstalledLocation.GetFileAsync(@"Custom_Commands");

            await VoiceCommandDefinitionManager.InstallCommandDefinitionsFromStorageFileAsync(vcd);
        }
        public static void RunCommand(VoicCommandActivatedEventArgs cmd)
        {
            SpeechRecognitionResult result = cmd.Result;
            string CommandName = result.RulePath[0];
            vcdLookup[CommandName].DynamicInvoke();
        }
    }
}
