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
using CrypTool.PluginBase.Miscellaneous;
using Matcher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Threading;

namespace CrypTool.Plugins.Matcher
{
    [Author("Plasmator", "coredevs@cryptool.org", "CrypTool 2 Team", "https://www.cryptool.org")]
    [PluginInfo("Matcher.Properties.Resources", "PluginCaption", "PluginTooltip", "Matcher/DetailedDescription/doc.xml", "Matcher/icon.png")]
    [ComponentCategory(ComponentCategory.ToolsMisc)]

    public class Matcher : ICrypComponent
    {
        #region Private Variables

        public class CribList
        {
            public string _PlainText { get; set; }
            public string _Keyword { get; set; }
            public int _Count { get; set; }
            public string _Cribs { get; set; }

            public CribList(string _pPlainText, string _pKeyword, int _pCount, string _pCribs)
            {
                _PlainText = _pPlainText;
                _Keyword = _pKeyword;
                _Count = _pCount;
                _Cribs = _pCribs;
            }

            public string CribToString()
            {
                return  _PlainText + " = " +
                        _Keyword + " = " +
                        _Count + " = " +
                        _Cribs + "\n";
            }

        }

        private MatcherPresentation _Presentation = new MatcherPresentation();
        private readonly MatcherSettings _Settings = new MatcherSettings();
        private Regex _Regex = new Regex("");
        private List<CribList> _CribList = new List<CribList>();
        private MatchCollection _Matches;
        private string _CribStr = "";
        private int _CribCount = 0;
        private string _OutputStr = "";

        private string _aInputPlainText = "";
        private string _bInputCrib = "";
        private string _cInputKeyword = "";
        private string _OutputResult = "";

        #endregion

        #region Data Properties

        [PropertyInfo(Direction.InputData, "aInputPlainTextCaption", "aInputPlainTextTooltip", true)]
        public string aInputPlainText
        {
            get
            {
                return _aInputPlainText;
            }
            set
            {
                _aInputPlainText = value;
                OnPropertyChanged(nameof(aInputPlainText));
            }
        }

        [PropertyInfo(Direction.InputData, "bInputCribCaption", "bInputCribTooltip", true)]
        public string bInputCrib
        {
            get
            {
                return _bInputCrib;
            }
            set
            {
                _bInputCrib = value;
                OnPropertyChanged(nameof(bInputCrib));
            }
        }

        [PropertyInfo(Direction.InputData, "cInputKeywordCaption", "cInputKeywordTooltip", true)]
        public string cInputKeyword
        {
            get
            {
                return _cInputKeyword;
            }
            set
            {
                _cInputKeyword = value;
                OnPropertyChanged(nameof(cInputKeyword));
            }
        }

        [PropertyInfo(Direction.OutputData, "OutputResultCaption", "OutputResultTooltip", false)]
        public string OutputResult
        {
            get
            {
                return _OutputResult;
            }
            set
            {
                _OutputResult = value;
                OnPropertyChanged(nameof(OutputResult));
            }
        }

        #endregion

        #region Helper Members

        private void StartMatching()
        {
            _Regex = new Regex( string.Join( "|" , bInputCrib.Split(',').Where(x => x.Length>0) ) );
            _Matches = _Regex.Matches(aInputPlainText);
            _CribCount = _Matches.Count;

            if (_CribCount > 0)
            {
                _CribStr = string.Join( "," , _Matches.Cast<Match>().Select(x => x.Value) );
                _CribList.Add(new CribList(aInputPlainText, cInputKeyword, _CribCount, _CribStr));
                _CribList = _CribList.OrderByDescending(x => x._Count).ThenBy(x => x._Keyword).ToList();

                if (_CribList.Count > 0)
                {
                    SetPresentationStatus(true);
                    OutputResult = _CribList[0].CribToString();
                }
            }
        }

        private void SetPresentationStatus(bool pUpdate)
        {
            Presentation.Dispatcher.Invoke(DispatcherPriority.Normal, (SendOrPostCallback)delegate
            {
                if (pUpdate==true)
                {
                    _Presentation.lvResults.ItemsSource = _CribList;
                }
                else
                {
                    _Presentation.lvResults.ItemsSource = null;
                    _CribList.Clear();
                }
            }, null);
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

        public void PreExecution()
        {
            SetPresentationStatus(false);
        }

        public void Execute()
        {
            StartMatching();
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

        #endregion]

    }
}
