using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace vstmanagertest.ViewModels.Pages
{
    public partial class DashboardViewModel : ObservableObject
    {
        // ObservableCollection property with [ObservableProperty] backing
        [ObservableProperty]
        private ObservableCollection<Plugin> _plugins;

        [ObservableProperty]
        private string _pluginPathsText;

        // List of directories to scan for VST plugins
        private readonly string[] pluginDirectories = new string[]
        {
            @"C:\Program Files\Steinberg\VstPlugins",
            @"C:\Program Files\Common Files\VST3",
            @"C:\Program Files\VSTPlugins",
            @"C:\Program Files (x86)\Steinberg\VstPlugins",
            @"C:\Program Files\Common Files\Steinberg\VST2",
            @"C:\Program Files\Common Files\VST2",

        };

        [ObservableProperty]
        private bool _showPath = true;

        // Constructor to initialize the collection
        public DashboardViewModel()
        {
            Plugins = new ObservableCollection<Plugin>();

            // Scan directories and load plugins
            foreach (var directory in pluginDirectories)
            {
                if (Directory.Exists(directory))
                {
                    var pluginFiles = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories)
                                                .Where(file => file.EndsWith(".dll") || file.EndsWith(".vst3"));

                    foreach (var file in pluginFiles)
                    {
                        Plugins.Add(new Plugin
                        {
                            Name = Path.GetFileNameWithoutExtension(file),
                            Path = file
                        });
                    }
                }
            }
        }
    }

    // Plugin class to hold the data
    public class Plugin
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
