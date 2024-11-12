/*
   Copyright CrypTool 2 Team <ct2contact@cryptool.org>

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using CrypTool.PluginBase;
using CrypTool.PluginBase.IO;
using CrypTool.PluginBase.Miscellaneous;
using LanguageStatisticsLib;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;

namespace CrypTool.Plugins.DictionaryAdvanced
{

    [Author("Plasmator", "coredevs@cryptool.org", "CrypTool 2 Team", "https://www.cryptool.org")]
    [PluginInfo("DictionaryAdvanced.Properties.Resources", "PluginCaption", "PluginTooltip", "DictionaryAdvanced/DetailedDescription/doc.xml", "DictionaryAdvanced/icon.png")]
    [ComponentCategory(ComponentCategory.ToolsDataInputOutput)]

    public class DictionaryAdvanced : ICrypComponent
    {
        #region Private Variables

        private readonly DictionaryAdvancedSettings _Settings = new DictionaryAdvancedSettings();
        private readonly Dictionary<int, string[]> _DictionaryCache = new Dictionary<int, string[]>();

        #endregion

        #region Data Properties

        [PropertyInfo(Direction.OutputData, "DictionaryArrayOutputCaption", "DictionaryArrayOutputTooltip", false)]
        public string[] OutputList
        {
            get;
            set;
        }

        #endregion

        #region IPlugin Members

        public ISettings Settings
        {
            get { return _Settings; }
        }

        public UserControl Presentation
        {
            get { return null; }
        }

        public void PreExecution()
        {
        }

        /// <summary>
        /// Excutes the Plugin - Output the Selected Dictionary as a String Array
        /// </summary>
        public void Execute()
        {

            ProgressChanged(0, 1);

            if (!_DictionaryCache.ContainsKey(_Settings.Language))
            {
                List<string> _Dictionary = LanguageStatistics.LoadDictionary(LanguageStatistics.LanguageCode(_Settings.Language), DirectoryHelper.DirectoryLanguageStatistics);
                _DictionaryCache.Add(_Settings.Language, _Dictionary.ToArray());
            }

            OutputList = _DictionaryCache[_Settings.Language].ToArray();
            switch (_Settings.CharacterCase)
            {
                case CharCase.Lowercase:
                    OutputList = OutputList.Select(x => x.ToLower()).ToArray();
                    break;

                case CharCase.Uppercase:
                    OutputList = OutputList.Select(x => x.ToUpper()).ToArray();
                    break;

                default:
                    break;
            }
            switch (_Settings.CharacterDirection)
            {
                case CharDir.Forward:
                    OutputList = OutputList;
                    break;

                case CharDir.Reverse:
                    OutputList = OutputList.Select(x => new string(x.Reverse().ToArray())).ToArray();
                    break;

                default:
                    break;
            }
            OnPropertyChanged(nameof(OutputList));

            ProgressChanged(1, 1);
        }

        public void PostExecution()
        {
        }

        public void Stop()
        {
        }

        public void Initialize()
        {
        }

        public void Dispose()
        {
        }

        #endregion

        #region Event Handling

        public event StatusChangedEventHandler OnPluginStatusChanged;

        public event GuiLogNotificationEventHandler OnGuiLogNotificationOccured;

        public event PluginProgressChangedEventHandler OnPluginProgressChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        private void GuiLogMessage(string message, NotificationLevel logLevel)
        {
            EventsHelper.GuiLogMessage(OnGuiLogNotificationOccured, this, new GuiLogEventArgs(message, this, logLevel));
        }

        private void OnPropertyChanged(string name)
        {
            EventsHelper.PropertyChanged(PropertyChanged, this, new PropertyChangedEventArgs(name));
        }

        private void ProgressChanged(double value, double max)
        {
            EventsHelper.ProgressChanged(OnPluginProgressChanged, this, new PluginProgressEventArgs(value, max));
        }

        #endregion
    }
}
