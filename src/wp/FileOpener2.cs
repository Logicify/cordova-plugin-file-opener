using Microsoft.Phone.Tasks;
using System;
using System.Diagnostics;
namespace WPCordovaClassLib.Cordova.Commands
{
    public class FileOpener2 : BaseCommand
    {
        public void open(string options)
        {
            //Options: [".\/89uqlqyms.avi","image\/png","FileOpener21439379467"]
            string mime = null;
            string path = null;
            string id = null;

            Debug.WriteLine("Options: " + options);
            try
            {
                string[] optionStrings = JSON.JsonHelper.Deserialize<string[]>(options);
                path = optionStrings[0];
                mime = optionStrings[1];
                id = optionStrings[2];
            }
            catch (Exception)
            {
                DispatchCommandResult(new PluginResult(PluginResult.Status.JSON_EXCEPTION));
                return;
            }

            MediaPlayerLauncher objMediaPlayerLauncher = new MediaPlayerLauncher();
            objMediaPlayerLauncher.Media = new Uri(path.Replace("./", ""), UriKind.Relative);
            objMediaPlayerLauncher.Location = MediaLocationType.Data;
            objMediaPlayerLauncher.Controls = MediaPlaybackControls.Pause | MediaPlaybackControls.Stop | MediaPlaybackControls.All;
            objMediaPlayerLauncher.Orientation = MediaPlayerOrientation.Landscape;
            objMediaPlayerLauncher.Show();

        }
    }
}