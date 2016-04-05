using System;
using System.Collections.Generic;


using Windows.Storage;
using Windows.ApplicationModel;
using Windows.ApplicationModel.VoiceCommands;

using Windows.System;
using Windows.Media.SpeechRecognition;
using Windows.ApplicationModel.Activation;
using Windows.Devices.SerialCommunication;
using Microsoft.Maker.Serial;
using Microsoft.Maker.RemoteWiring;
using System.Diagnostics;


namespace CustomCortanaCommands
{
    
    
   class Functions
    {
        private void Test()
        {
            Debug.WriteLine("Functions started");
        }

        /*  private readonly static IReadOnlyDictionary<string, Delegate> vcdLookup = new Dictionary<string, Delegate>{

              {"Moving", (Action)(async () => {

              })},

              {"Massage", (Action)(async () => { 

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
          }*/
    }

}
