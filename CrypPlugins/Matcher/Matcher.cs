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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;

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

        }

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

        [PropertyInfo(Direction.InputData, "aInputPlainTextCaption", "aInputPlainTextTooltip", false)]
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

        [PropertyInfo(Direction.InputData, "bInputCribCaption", "bInputCribTooltip", false)]
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

        [PropertyInfo(Direction.InputData, "cInputKeywordCaption", "cInputKeywordTooltip", false)]
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

        [PropertyInfo(Direction.OutputData, "OutputResultCaption", "OutputResultTooltip", true)]
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
            _CribList.Clear();
        }

        public void Execute()
        {
            _Regex = new Regex(bInputCrib.Replace(",","|"));
            _Matches = _Regex.Matches(aInputPlainText);
            _CribCount = _Matches.Count;

            if ( _CribCount > 0 )
            {
                _CribStr = string.Join(",",
                            _Matches
                            .Cast<Match>()
                            .Select(x => x.Value)
                            .ToArray()
                            );

                _CribList.Add(new CribList(aInputPlainText, cInputKeyword, _CribCount, _CribStr));
                _CribList = _CribList.OrderByDescending(x => x._Count).ThenBy(x=>x._Keyword).ToList();

                if (_CribList.Count > 0)
                {
                    _OutputStr = "";
                    foreach (var _Crib in _CribList)
                    {
                        _OutputStr +=   _Crib._PlainText + " = " +
                                        _Crib._Keyword + " = " +
                                        _Crib._Count + " = " +
                                        _Crib._Cribs + "\n";
                    }
                    OutputResult = _OutputStr;
                }
            }

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
