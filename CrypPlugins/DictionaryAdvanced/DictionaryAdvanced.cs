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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
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
        private readonly TextInfo _TextInfo = Thread.CurrentThread.CurrentCulture.TextInfo;

        private string[,] _LanguageCodes = new string[16, 2] {
            {"English","en"} , {"German","de"} , {"French","fr"} , {"Spanish","es"} , {"Italian","it"} , {"Hungarian","hu"} ,
            {"Russian","ru"} , {"Slovak","cs"} , {"Latin","la"} , {"Greek","el"} , {"Dutch","nl"} , {"Swedish","sv"} ,
            {"Portuguese ","pt"} , {"Polish","pl"} , {"Turkish","tr"} , {"UserDefined","zz"} };

        private List<string> _Dictionary = new List<string>();
        private string _UserDefined = AppDomain.CurrentDomain.BaseDirectory.ToString() + "CrypData\\UserDefined.txt";

        #endregion

        #region Data Properties

        [PropertyInfo(Direction.OutputData, "DictionaryArrayOutputCaption", "DictionaryArrayOutputTooltip", false)]
        public string[] OutputList
        {
            get;
            set;
        }

        [PropertyInfo(Direction.OutputData, "DictionaryStringOutputCaption", "DictionaryStringOutputTooltip", false)]
        public string OutputString
        {
            get;
            set;
        }

        [PropertyInfo(Direction.OutputData, "DictionaryLengthOutputCaption", "DictionaryLengthOutputTooltip", false)]
        public int OutputLength
        {
            get;
            set;
        }

        #endregion

        #region Thread Members

        private Thread _trLoop;

        private void trLoop()
        {
            ProgressChanged(0, 1);
            GuiLogMessage("Loop Begin = " + DateTime.Now.ToString(), NotificationLevel.Info);

            foreach (string _Word in OutputList)
            {
                OutputString = _Word;
                OnPropertyChanged(nameof(OutputString));
            }

            GuiLogMessage("Loop End = " + DateTime.Now.ToString(), NotificationLevel.Info);
            ProgressChanged(1, 1);
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
            GuiLogMessage("Execute Start = " + DateTime.Now.ToString(), NotificationLevel.Info);

            // Select Dictionary Language

            if (_LanguageCodes[_Settings.Language,0]=="UserDefined")
            {
                if (File.Exists(_UserDefined))
                {
                    _DictionaryCache.Remove(_Settings.Language);
                    _DictionaryCache.Add(_Settings.Language, File.ReadAllLines(_UserDefined));
                }
                else
                {
                    GuiLogMessage("Dictionary File Missing\n" + _UserDefined, NotificationLevel.Error);
                    return;
                }
            }
            else
            {
                if (!_DictionaryCache.ContainsKey(_Settings.Language))
                {
                    _Dictionary = LanguageStatistics.LoadDictionary(LanguageStatistics.LanguageCode(_Settings.Language), DirectoryHelper.DirectoryLanguageStatistics);
                    _DictionaryCache.Add(_Settings.Language, _Dictionary.ToArray());
                }
            }

            OutputList = _DictionaryCache[_Settings.Language].ToArray();
            OutputLength = OutputList.Length;

            // Select Character Format
            CharFormat _CharFormat = _Settings.CharacterFormat;
            switch (_CharFormat)
            {
                case CharFormat.LowerCase:
                    OutputList = OutputList.Select(x => x.ToLower()).ToArray();
                    break;

                case CharFormat.TitleCase:
                    OutputList = OutputList.Select(x => _TextInfo.ToTitleCase(x.ToLower())).ToArray();
                    break;

                case CharFormat.UpperCase:
                    OutputList = OutputList.Select(x => x.ToUpper()).ToArray();
                    break;

                case CharFormat.BasicL33T:
                case CharFormat.MediumL33T:
                case CharFormat.HardL33T:

                    OutputList = OutputList.Select(x => x
                        .Replace("O", "0") // Basic = Vowels = A , E , I , O
                        .Replace("I", "1")
                        .Replace("E", "3")
                        .Replace("A", "4")
                        ).ToArray();

                    if ( _CharFormat==CharFormat.MediumL33T || _CharFormat== CharFormat.HardL33T )
                    {
                        OutputList = OutputList.Select(x => x
                            .Replace("S", "5") // + Medium = Consonants = S , T , Z
                            .Replace("T", "7")
                            .Replace("Z", "2")
                        ).ToArray();
                    }

                    if ( _CharFormat==CharFormat.HardL33T )
                    {
                        OutputList = OutputList.Select(x => x
                            .Replace("B", "8") // + Hard = Consonants = B , G , P
                            .Replace("G", "6")
                            .Replace("P", "9")
                        ).ToArray();
                    }

                    break;

                default:
                    break;
            }

            // Select Character Direction
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

            // Update Output
            OnPropertyChanged(nameof(OutputList));
            OnPropertyChanged(nameof(OutputLength));

            // Output Single String or Loop Through Words
            if (_Settings.StringOutputType==OutputType.Single)
            {
                OutputString = string.Join(",", OutputList);
                OnPropertyChanged(nameof(OutputString));
            }
            else if (_Settings.StringOutputType == OutputType.Loop)
            {
                if (_trLoop != null)
                {
                    if (_trLoop.IsAlive)
                    {
                        _trLoop.Abort();
                        _trLoop = null;
                        GuiLogMessage("Loop Abort = " + DateTime.Now.ToString(), NotificationLevel.Info);
                    }
                }
                _trLoop = new Thread(new ThreadStart(trLoop))
                {
                    IsBackground = false
                };
                _trLoop.Start();
            }

            GuiLogMessage("Execute Stop = " + DateTime.Now.ToString(), NotificationLevel.Info);
            ProgressChanged(1, 1);

        }

        public void PostExecution()
        {
        }

        public void Stop()
        {
            if (_trLoop != null)
            {
                if (_trLoop.IsAlive)
                {
                    _trLoop.Abort();
                    _trLoop = null;
                    GuiLogMessage("Loop Abort = " + DateTime.Now.ToString(), NotificationLevel.Info);
                }
            }
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
