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
using DictionaryAdvanced;
using LanguageStatisticsLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Threading;

namespace CrypTool.Plugins.DictionaryAdvanced
{

    [Author("Plasmator", "coredevs@cryptool.org", "CrypTool 2 Team", "https://www.cryptool.org")]
    [PluginInfo("DictionaryAdvanced.Properties.Resources", "PluginCaption", "PluginTooltip", "DictionaryAdvanced/DetailedDescription/doc.xml", "DictionaryAdvanced/icon.png")]
    [ComponentCategory(ComponentCategory.ToolsDataInputOutput)]

    public class DictionaryAdvanced : ICrypComponent
    {
        #region Private Variables

        private DictionaryAdvancedPresentation _Presentation = new DictionaryAdvancedPresentation();
        private readonly DictionaryAdvancedSettings _Settings = new DictionaryAdvancedSettings();
        private readonly TextInfo _TextInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
        private Thread _trLoop;
        private bool _trLoopStatus;

        private string[,] _LanguageCodes = new string[16, 2] {
            {"English","en"} , {"German","de"} , {"French","fr"} , {"Spanish","es"} , {"Italian","it"} , {"Hungarian","hu"} ,
            {"Russian","ru"} , {"Slovak","cs"} , {"Latin","la"} , {"Greek","el"} , {"Dutch","nl"} , {"Swedish","sv"} ,
            {"Portuguese ","pt"} , {"Polish","pl"} , {"Turkish","tr"} , {"UserDefined","zz"} };

        private string _UserDefined = AppDomain.CurrentDomain.BaseDirectory.ToString() + "CrypData\\UserDefined.txt";
        private readonly Dictionary<int, string[]> _DictionaryCache = new Dictionary<int, string[]>();
        private List<string> _Dictionary = new List<string>();
        private CharFormat _CharFormat;

        private string[] _OutputList;
        private int _OutputListLength;
        private string _OutputString;

        #endregion

        #region Data Properties

        [PropertyInfo(Direction.OutputData, "DictionaryArrayOutputCaption", "DictionaryArrayOutputTooltip", false)]
        public string[] OutputList
        {
            get
            {
                return _OutputList;
            }
            set
            {
                _OutputList = value;
                OnPropertyChanged(nameof(OutputList));
            }
        }

        [PropertyInfo(Direction.OutputData, "DictionaryStringOutputCaption", "DictionaryStringOutputTooltip", false)]
        public string OutputString
        {
            get
            {
                return _OutputString;
            }
            set
            {
                _OutputString = value;
                OnPropertyChanged(nameof(OutputString));
            }
        }

        [PropertyInfo(Direction.OutputData, "DictionaryLengthOutputCaption", "DictionaryLengthOutputTooltip", false)]
        public int OutputLength
        {
            get
            { 
                return _OutputListLength;
            }
            set
            {
                _OutputListLength = value;
                OnPropertyChanged(nameof(OutputLength));
            }
        }

        #endregion

        #region Helper Members

        private void trLoop()
        {
            /*

            ProgressChanged(0, 1);
            GuiLogMessage("Loop Begin = " + DateTime.Now.ToString(), NotificationLevel.Info);

            // [ Future Code Here ]

            GuiLogMessage("Loop End = " + DateTime.Now.ToString(), NotificationLevel.Info);
            ProgressChanged(1, 1);

            */
        }

        private void SetPreStatus(string pStatus)
        {
            Presentation.Dispatcher.Invoke(DispatcherPriority.Normal, (SendOrPostCallback)delegate
            { _Presentation.Status.Content = (pStatus + "   "); }, null);
        }

        #endregion

        #region IPlugin Members

        public ISettings Settings
        {
            get { return _Settings; }
        }

        public UserControl Presentation
        {
            get { return _Presentation; }
        }

        /// <summary>
        /// PreExcution - Process & Load Selected Dictionary
        /// </summary>
        public void PreExecution()
        {

            // Load Selected Dictionary
            if (_LanguageCodes[_Settings.Language, 0] == "UserDefined")
            {
                if (File.Exists(_UserDefined))
                {
                    // Cache -> Refresh ( Remove & Add ) UserDefined Dictionary
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
                // Cache -> Load LanguageStatistics Dictionary
                if (!_DictionaryCache.ContainsKey(_Settings.Language))
                {
                    _Dictionary = LanguageStatistics.LoadDictionary(LanguageStatistics.LanguageCode(_Settings.Language), DirectoryHelper.DirectoryLanguageStatistics);
                    _DictionaryCache.Add(_Settings.Language, _Dictionary.ToArray());
                }
            }

            // OutputList Variable <- Load Cache Dictionary
            _OutputList = _DictionaryCache[_Settings.Language].ToArray();
            _OutputListLength = _OutputList.Length;

            // OutputList Variable <- Character Format
            _CharFormat = _Settings.CharacterFormat;
            switch (_CharFormat)
            {
                case CharFormat.LowerCase:
                    _OutputList = _OutputList.Select(x => x.ToLower()).ToArray();
                    break;

                case CharFormat.TitleCase:
                    _OutputList = _OutputList.Select(x => _TextInfo.ToTitleCase(x.ToLower())).ToArray();
                    break;

                case CharFormat.UpperCase:
                    _OutputList = _OutputList.Select(x => x.ToUpper()).ToArray();
                    break;

                case CharFormat.BasicL33T:
                case CharFormat.MediumL33T:
                case CharFormat.HardL33T:

                    _OutputList = _OutputList.Select(x => x
                        .Replace("O", "0") // Basic = Vowels = A , E , I , O
                        .Replace("I", "1")
                        .Replace("E", "3")
                        .Replace("A", "4")
                        ).ToArray();

                    if (_CharFormat == CharFormat.MediumL33T || _CharFormat == CharFormat.HardL33T)
                    {
                        _OutputList = _OutputList.Select(x => x
                            .Replace("S", "5") // + Medium = Consonants = S , T , Z
                            .Replace("T", "7")
                            .Replace("Z", "2")
                        ).ToArray();
                    }

                    if (_CharFormat == CharFormat.HardL33T)
                    {
                        _OutputList = _OutputList.Select(x => x
                            .Replace("B", "8") // + Hard = Consonants = B , G , P
                            .Replace("G", "6")
                            .Replace("P", "9")
                        ).ToArray();
                    }

                    break;

                default:
                    break;
            }

            // OutputList Variable <- Character Direction
            switch (_Settings.CharacterDirection)
            {
                case CharDir.Reverse:
                    _OutputList = _OutputList.Select(x => new string(x.Reverse().ToArray())).ToArray();
                    break;

                case CharDir.Forward:
                default:
                    break;
            }

            // OutputList Variable <- Publish
            OutputList = _OutputList;
            OutputLength = _OutputListLength;

            // OutputString Variable <- Load Formatted Dictionary
            if (_Settings.StringOutputType == OutputType.Single)
            {
                _OutputString = string.Join(",", _OutputList);
                OutputString = _OutputString;
            }
            else if (_Settings.StringOutputType == OutputType.Loop)
            {
                foreach (string _Word in _OutputList)
                {
                    // OutputString Variable Loop <- Publish
                    _OutputString = _Word;
                    OutputString = _OutputString;
                    SetPreStatus(_OutputString);
                }
            }

            SetPreStatus("Completed");

        }

        /// <summary>
        /// Execute the Plugin
        /// </summary>
        public void Execute()
        {
            /*

            ProgressChanged(0, 1);
            GuiLogMessage("Execute Start = " + DateTime.Now.ToString(), NotificationLevel.Info);

            // [ Future Code Here ]

            GuiLogMessage("Execute Stop = " + DateTime.Now.ToString(), NotificationLevel.Info);
            ProgressChanged(1, 1);

            */
        }

        public void PostExecution()
        {
            SetPreStatus("Ready");
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
